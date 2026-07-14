# Release Checklist

Use this checklist before publishing a NuGet package.

## Validate

```powershell
dotnet restore Mvx.ApiClient.Net.slnx
dotnet build Mvx.ApiClient.Net.slnx --configuration Release --no-restore
dotnet test Mvx.ApiClient.Net.slnx --configuration Release --no-build
dotnet pack src/Mvx.ApiClient.Net/Mvx.ApiClient.Net.csproj --configuration Release --no-build
.\eng\package-smoke-test.ps1 -TargetFramework net8.0
.\eng\package-smoke-test.ps1 -TargetFramework net10.0
.\eng\api-surface.ps1
.\eng\handwritten-surface.ps1
.\eng\docs.ps1
```

## Review

- Public API changes are intentional and reflected in `tests/Mvx.ApiClient.Net.Test/PublicApi.Shipped.txt`.
- Every implemented path remains non-deprecated and non-excluded in the approved upstream snapshot.
- Operations with incomplete OpenAPI responses have live contract evidence before publication.
- README examples compile through the package smoke test.
- XML documentation is generated without public documentation warnings.
- Package metadata is current.
- CHANGELOG has release notes for the version being published.
- Docs build successfully.

## Versioning

This package follows semantic versioning.

Because `1.0.0` has already been released, breaking public API changes should use a new major version unless compatibility aliases are kept for the previous API.
