param(
    [switch]$Update,
    [uri]$SpecificationUri = "https://api.multiversx.com/-json"
)

$ErrorActionPreference = "Stop"
$repositoryRoot = Split-Path -Parent $PSScriptRoot
$snapshotPath = Join-Path $PSScriptRoot "multiversx-get-surface.json"

# The live specification does not mark this compatibility route as deprecated, but its operation
# identifier explicitly labels it temporary and /mex/pairs is the canonical documented route.
$explicitExclusions = @{
    "/mex-pairs" = "Temporary compatibility alias for /mex/pairs."
}

function Get-SchemaSignature {
    param($Schema)

    if ($null -eq $Schema) {
        return $null
    }

    if ($Schema.'$ref') {
        return $Schema.'$ref'
    }

    if ($Schema.type -eq "array") {
        $itemSignature = Get-SchemaSignature $Schema.items
        return "array<$itemSignature>"
    }

    if ($Schema.type) {
        if ($Schema.format) {
            return "$($Schema.type):$($Schema.format)"
        }

        return [string]$Schema.type
    }

    return "unspecified"
}

function Get-CanonicalSurface {
    param($Specification)

    $operations = foreach ($pathProperty in $Specification.paths.PSObject.Properties) {
        $operation = $pathProperty.Value.get
        if ($null -eq $operation) {
            continue
        }

        $path = $pathProperty.Name
        $response = $operation.responses.'200'
        $contentTypes = if ($response.content) {
            @($response.content.PSObject.Properties.Name | Sort-Object)
        }
        else {
            @()
        }
        $jsonSchema = $response.content.'application/json'.schema
        $isDeprecated = $operation.deprecated -eq $true
        $exclusionReason = if ($isDeprecated) {
            "Marked deprecated by the upstream OpenAPI operation."
        }
        elseif ($explicitExclusions.ContainsKey($path)) {
            $explicitExclusions[$path]
        }
        else {
            $null
        }
        $documentationStatus = if ($exclusionReason) {
            "excluded"
        }
        elseif ($null -eq $response -or $contentTypes.Count -eq 0 -or $null -eq $jsonSchema) {
            "requires-live-validation"
        }
        else {
            "documented"
        }

        $parameters = foreach ($parameter in @($operation.parameters)) {
            [ordered]@{
                name = [string]$parameter.name
                location = [string]$parameter.in
                required = $parameter.required -eq $true
                deprecated = $parameter.deprecated -eq $true
                type = [string]$parameter.schema.type
                format = [string]$parameter.schema.format
                style = [string]$parameter.style
                explode = if ($null -eq $parameter.explode) { $null } else { $parameter.explode -eq $true }
                enum = if ($null -eq $parameter.schema.enum) { @() } else { @($parameter.schema.enum) }
            }
        }

        [ordered]@{
            path = $path
            tag = [string]@($operation.tags)[0]
            operationId = [string]$operation.operationId
            summary = [string]$operation.summary
            deprecated = $isDeprecated
            documentationStatus = $documentationStatus
            exclusionReason = $exclusionReason
            parameters = @($parameters | Sort-Object location, name)
            response = [ordered]@{
                contentTypes = $contentTypes
                jsonSchema = Get-SchemaSignature $jsonSchema
            }
        }
    }

    return [ordered]@{
        source = $SpecificationUri.AbsoluteUri
        openApiVersion = [string]$Specification.openapi
        apiVersion = [string]$Specification.info.version
        operations = @($operations | Sort-Object path)
    }
}

$specificationContent = (Invoke-WebRequest -Uri $SpecificationUri).Content
$specification = $specificationContent | ConvertFrom-Json -Depth 100
$surface = Get-CanonicalSurface $specification
$canonicalJson = $surface | ConvertTo-Json -Depth 20

if ($Update) {
    Set-Content -LiteralPath $snapshotPath -Value $canonicalJson -Encoding utf8NoBOM
    Write-Host "Updated $snapshotPath with $($surface.operations.Count) GET operations."
    exit 0
}

if (-not (Test-Path -LiteralPath $snapshotPath)) {
    throw "API surface snapshot does not exist. Run ./eng/api-surface.ps1 -Update."
}

$approvedJson = Get-Content -Raw -LiteralPath $snapshotPath
if ($approvedJson.TrimEnd() -cne $canonicalJson.TrimEnd()) {
    throw "The live MultiversX GET surface differs from eng/multiversx-get-surface.json. Review the upstream change, then run ./eng/api-surface.ps1 -Update."
}

$documented = @($surface.operations | Where-Object documentationStatus -eq "documented").Count
$requiresValidation = @($surface.operations | Where-Object documentationStatus -eq "requires-live-validation").Count
$excluded = @($surface.operations | Where-Object documentationStatus -eq "excluded").Count
Write-Host "MultiversX GET surface is unchanged: $documented documented, $requiresValidation requiring live validation, $excluded excluded."
