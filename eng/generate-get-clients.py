"""Generate the reviewed MultiversX GET client surface from its OpenAPI document.

The generator handles repetitive declarations only. Semantic type rules and the
explicit exclusions below are part of the package contract and require review.
"""

from __future__ import annotations

import argparse
import hashlib
import json
import keyword
import re
from pathlib import Path


EXCLUDED_QUERY_PARAMETERS = {"fields", "extract"}
# These parameters are emitted by ApiQuery decorators in the upstream OpenAPI
# document, but the corresponding controller actions only consume the path
# parameter. Sending them would expose duplicate or entirely phantom inputs.
EXCLUDED_QUERY_PARAMETERS_BY_PATH = {
    ("/auctions/{id}", "auctionId"),
    ("/accounts/{address}/auctions/count", "address"),
    ("/collections/{collection}/auctions", "collection"),
    ("/collections/{collection}/auctions/count", "collection"),
}
EXISTING_PATHS = {
    "/stats", "/economics", "/constants", "/about",
    "/mex/economics", "/mex/pairs", "/mex/pairs/count",
    "/mex/pairs/{baseId}/{quoteId}", "/mex/tokens", "/mex/tokens/count",
    "/mex/tokens/{identifier}", "/mex/farms", "/mex/farms/count",
}
TAG_NAMES = {
    "dapp/config": "DappConfig",
    "HealthCheck": "HealthCheck",
    "TransactionsBatch": "TransactionBatches",
    "xexchange": "XExchange",
}
SPECIAL_RESPONSES = {
    "/tokens/{identifier}/logo/png": ("MvxApiContent", "content"),
    "/tokens/{identifier}/logo/svg": ("MvxApiContent", "content"),
    "/providers/{address}/avatar": ("MvxApiContent", "content"),
    "/identities/{identifier}/avatar": ("MvxApiContent", "content"),
    "/mex/pairs/count": ("long", "number"),
    "/mex/farms/count": ("long", "number"),
    "/mex/tokens/count": ("long", "number"),
    "/accounts/{address}/esdthistory/count": ("long", "number"),
    "/hello": ("string", "string"),
    "/nodes/versions": ("IReadOnlyDictionary<string, decimal>", "json"),
    "/batch/{address}/{id}": ("TransactionBatchResult", "json"),
    "/batch/{address}": ("IReadOnlyList<TransactionBatchResult>", "json"),
    "/accounts/{address}/upgrades": ("IReadOnlyList<ContractUpgrades>", "json"),
    "/nfts/{identifier}/thumbnail": ("MvxApiContent", "content"),
    "/providers/{address}/accounts": ("IReadOnlyList<ProviderAccount>", "json"),
}
METHOD_NAME_OVERRIDES = {
    "/delegation-legacy": "GetDelegationLegacyAsync",
    "/miniblocks/{miniBlockHash}": "GetMiniBlockAsync",
    "/providers/{address}/avatar": "GetProviderAvatarAsync",
    "/auctions/{id}": "GetAuctionAsync",
    "/nfts/{identifier}/thumbnail": "GetNftThumbnailAsync",
    "/collections/{identifier}/accounts": "GetCollectionAccountsAsync",
    "/mex/tokens/prices/daily/{identifier}": "GetTokenDailyPricesAsync",
    "/mex/tokens/prices/hourly/{identifier}": "GetTokenHourlyPricesAsync",
    "/transfers": "GetTransfersAsync",
    "/transfers/count": "GetTransfersCountAsync",
}
MODEL_NAMES = {
    "Auctions": "AuctionSummary",
    "Bids": "Bid",
    "Events": "Event",
    "PpuMetadata": "ProcessingUnitMetadata",
    "ProviderUnstakedTokens": "ProviderUnstakedToken",
    "TokenOwnersHistory": "TokenOwnerHistory",
    "UnlockMileStoneModel": "UnlockMilestone",
}
ATOMIC_NAMES = {
    "amount", "balance", "burnt", "circulatingsupply", "delegated",
    "developerreward", "fee", "initialminted", "locked", "minted",
    "stake", "supply", "topup", "totalstake", "value",
}
FRACTIONAL_NAMES = {
    "apr", "baseapr", "circulatingsupply", "marketcap", "occurrencepercentage",
    "percent", "previous24hvolume", "ratingmodifier", "score", "servicefee",
    "stakepercent", "staked", "syncprogress", "tokenmarketcap", "topupapr",
    "totalliquidity", "totalsupply", "totalvalue", "totalvolume24h", "valueusd",
    "volume24h",
}


def pascal(value: str) -> str:
    parts = re.findall(r"[A-Z]+(?=[A-Z][a-z]|\d|$)|[A-Z]?[a-z]+|\d+", value.replace("-", " ").replace("/", " ").replace("_", " "))
    result = "".join(part[:1].upper() + part[1:] for part in parts)
    if not result:
        result = "Value"
    if result[0].isdigit():
        result = "Value" + result
    return result


def camel(value: str) -> str:
    name = pascal(value)
    name = name[:1].lower() + name[1:]
    return "@" + name if keyword.iskeyword(name) or name in {"event", "params", "operator"} else name


def enum_member(value: str) -> str:
    if value == "":
        return "Empty"
    name = pascal(value)
    return name if name != "Unknown" else "UpstreamUnknown"


def model_property_name(schema_name: str, property_name: str) -> str:
    name = pascal(property_name)
    return name + "Value" if name == schema_name else name


def csharp_model_name(schema_name: str) -> str:
    return MODEL_NAMES.get(schema_name, schema_name)


def ref_name(schema: dict) -> str | None:
    ref = schema.get("$ref")
    if not ref:
        for item in schema.get("allOf", []):
            if "$ref" in item:
                ref = item["$ref"]
                break
    return ref.rsplit("/", 1)[-1] if ref else None


def is_nullable(schema: dict, required: bool = False) -> bool:
    return schema.get("nullable", False) or not required


def numeric_type(name: str, schema_name: str) -> str:
    lower = name.lower()
    if schema_name == "Provider" and lower in {"stake", "topup", "locked"}:
        return "BigInteger"
    if lower in FRACTIONAL_NAMES or lower == "value" and schema_name == "MexTokenChart":
        return "decimal"
    if "price" in lower and "gasprice" not in lower:
        return "decimal"
    if any(part in lower for part in ("liquidity", "percentage", "percent", "volume")):
        return "decimal"
    return "long"


def model_type(schema: dict, property_name: str = "", schema_name: str = "", required: bool = True) -> str:
    if schema_name == "TokenAssets" and property_name == "lockedAccounts":
        return "JsonElement?"
    if schema_name == "Provider":
        if property_name in {"serviceFee", "apr"}:
            return "decimal?"
        if property_name == "numUsers":
            return "long?"
        if property_name in {"cumulatedRewards", "initialOwnerFunds", "totalUnStaked"}:
            return "BigInteger?"
    if property_name == "distribution" and schema_name in {"Identity", "NodeAuction"}:
        return "IReadOnlyDictionary<string, decimal>?"
    referenced = ref_name(schema)
    if referenced == "NftMedia" and property_name == "media":
        base = "IReadOnlyList<NftMedia>"
    elif referenced == "TokenOwnersHistory" and property_name == "ownersHistory":
        base = "IReadOnlyList<TokenOwnerHistory>"
    elif referenced:
        base = "BigInteger" if referenced == "Amount" else csharp_model_name(referenced)
    else:
        kind = schema.get("type")
        if kind == "array":
            item = model_type(schema.get("items", {}), property_name, schema_name, True).rstrip("?")
            base = f"IReadOnlyList<{item}>"
        elif kind in {"number", "integer"}:
            base = numeric_type(property_name, schema_name)
        elif kind == "boolean":
            base = "bool"
        elif kind == "string":
            lower_name = property_name.lower()
            if lower_name in ATOMIC_NAMES or lower_name.endswith(("stake", "topup", "rewards", "funds")) or lower_name == "relayedvalue":
                base = "BigInteger"
            else:
                base = "string"
        elif kind == "object" and schema.get("additionalProperties"):
            value_type = model_type(schema["additionalProperties"], property_name, schema_name, True).rstrip("?")
            base = f"IReadOnlyDictionary<string, {value_type}>"
        else:
            base = "JsonElement"
    if is_nullable(schema, required) and base not in {"string", "JsonElement"} and not base.startswith(("IReadOnly",)):
        return base + "?"
    if is_nullable(schema, required) and base in {"string", "JsonElement"}:
        return base + "?"
    if is_nullable(schema, required) and base.startswith("IReadOnly"):
        return base + "?"
    return base


def query_schema(parameter: dict) -> dict:
    return parameter.get("schema", parameter)


def query_enum_values(parameter: dict) -> list[str]:
    schema = query_schema(parameter)
    return schema.get("enum") or schema.get("items", {}).get("enum") or []


def query_type(parameter: dict, enum_name: str | None) -> str:
    schema = query_schema(parameter)
    kind = schema.get("type")
    required = parameter.get("required", False)
    if enum_name:
        base = enum_name
        if kind == "array":
            base = f"IReadOnlyCollection<{enum_name}>"
    elif kind == "array":
        item_kind = schema.get("items", {}).get("type")
        item = "long" if item_kind in {"number", "integer"} else "string"
        base = f"IReadOnlyCollection<{item}>"
    elif kind in {"number", "integer"}:
        base = "long"
    elif kind == "boolean":
        base = "bool"
    else:
        base = "string"
    if not required:
        base += "?"
    return base


def response_type(operation: dict, path: str) -> tuple[str, str]:
    if path in SPECIAL_RESPONSES:
        return SPECIAL_RESPONSES[path]
    if path.endswith("/count"):
        return "long", "number"
    response = operation.get("responses", {}).get("200", {})
    content = response.get("content", {})
    schema = content.get("application/json", {}).get("schema")
    if schema:
        referenced = ref_name(schema)
        if referenced:
            return csharp_model_name(referenced), "json"
        kind = schema.get("type")
        if kind == "array":
            item = model_type(schema.get("items", {}), required=True).rstrip("?")
            return f"IReadOnlyList<{item}>", "json"
        if kind in {"number", "integer"}:
            return "long", "json"
        if kind == "string":
            return "string", "json"
        if kind == "boolean":
            return "bool", "json"
        return "JsonElement", "json"
    content_types = list(content)
    if any(value.startswith(("image/", "application/octet-stream")) for value in content_types):
        return "MvxApiContent", "content"
    if any(value.startswith("text/") for value in content_types):
        return "string", "string"
    return "JsonElement", "json"


def operation_name(operation: dict, path: str | None = None) -> str:
    if path in METHOD_NAME_OVERRIDES:
        return METHOD_NAME_OVERRIDES[path]
    raw = operation.get("operationId", "Get")
    raw = raw.rsplit("_", 1)[-1]
    name = pascal(raw)
    return name + "Async" if not name.endswith("Async") else name


def tag_name(tag: str) -> str:
    return TAG_NAMES.get(tag, pascal(tag))


def load_operations(spec: dict) -> list[dict]:
    result = []
    for path, path_item in spec["paths"].items():
        operation = path_item.get("get")
        if not operation or operation.get("deprecated"):
            continue
        operation = dict(operation)
        parameters = list(path_item.get("parameters", [])) + list(operation.get("parameters", []))
        declared_path_names = {p.get("name") for p in parameters if p.get("in") == "path"}
        synthetic = [
            {"name": name, "in": "path", "required": True, "schema": {"type": "string"}}
            for name in re.findall(r"{([^}]+)}", path)
            if name not in declared_path_names
        ]
        operation["parameters"] = synthetic + parameters
        result.append({"path": path, "operation": operation, "tag": tag_name(operation["tags"][0])})
    return result


def referenced_schemas(node: object) -> set[str]:
    result: set[str] = set()
    if isinstance(node, dict):
        ref = node.get("$ref")
        if isinstance(ref, str) and ref.startswith("#/components/schemas/"):
            result.add(ref.rsplit("/", 1)[-1])
        for value in node.values():
            result.update(referenced_schemas(value))
    elif isinstance(node, list):
        for value in node:
            result.update(referenced_schemas(value))
    return result


def reachable_schemas(spec: dict, operations: list[dict]) -> set[str]:
    schemas = spec.get("components", {}).get("schemas", {})
    reachable: set[str] = set()
    for item in operations:
        reachable.update(referenced_schemas(item["operation"].get("responses", {}).get("200", {})))
    pending = list(reachable)
    while pending:
        name = pending.pop()
        for dependency in referenced_schemas(schemas.get(name, {})):
            if dependency not in reachable:
                reachable.add(dependency)
                pending.append(dependency)
    return reachable


def generate_models(spec: dict, operations: list[dict]) -> str:
    lines = [
        "// <auto-generated />", "#nullable enable", "using System.Numerics;", "using System.Runtime.Serialization;",
        "using System.Text.Json;", "using System.Text.Json.Serialization;", "", "namespace Mvx.ApiClient.Net.Models.Api;", ""
    ]
    schemas = spec.get("components", {}).get("schemas", {})
    reachable = reachable_schemas(spec, operations)
    for schema_name, schema in schemas.items():
        if schema_name not in reachable:
            continue
        csharp_schema_name = csharp_model_name(schema_name)
        properties = schema.get("properties", {})
        required = set(schema.get("required", []))
        if schema_name == "AccountAssets":
            properties = {
                "name": {"type": "string"},
                "description": {"type": "string"},
                "social": {"type": "object", "additionalProperties": {"type": "string"}},
                "tags": {"type": "array", "items": {"type": "string"}},
                "icon": {"type": "string"},
                "iconPng": {"type": "string"},
                "iconSvg": {"type": "string"},
            }
            required = set()
        if schema_name == "TokenOwnersHistory":
            properties = {"address": {"type": "string"}, "timestamp": {"type": "number"}}
            required = {"address", "timestamp"}
        if schema_name == "Amount":
            continue
        lines += [f"/// <summary>Represents the {csharp_schema_name} response returned by the MultiversX API.</summary>", f"public sealed class {csharp_schema_name}", "{"]
        for property_name, prop_schema in properties.items():
            values = prop_schema.get("enum", [])
            prop_type = f"{csharp_schema_name}{pascal(property_name)}?" if values else model_type(prop_schema, property_name, schema_name, False)
            csharp_property_name = model_property_name(csharp_schema_name, property_name)
            lines += [
                f"    /// <summary>Gets the upstream <c>{property_name}</c> value.</summary>",
                f"    [JsonPropertyName(\"{property_name}\")]",
                f"    public {prop_type} {csharp_property_name} {{ get; init; }}", ""
            ]
        lines += ["}", ""]
        for property_name, prop_schema in properties.items():
            values = prop_schema.get("enum", [])
            if not values:
                continue
            enum_name = f"{csharp_schema_name}{pascal(property_name)}"
            lines += [f"/// <summary>Known values for <see cref=\"{csharp_schema_name}.{model_property_name(csharp_schema_name, property_name)}\"/>.</summary>", f"public enum {enum_name}", "{", "    /// <summary>The API returned a value unknown to this package version.</summary>", "    Unknown = 0,"]
            for index, value in enumerate(values, 1):
                lines += [f"    /// <summary>The upstream <c>{value or '(empty)'}</c> value.</summary>", f"    [EnumMember(Value = \"{value}\")]", f"    {enum_member(value)} = {index},"]
            lines += ["}", ""]
    return "\n".join(lines)


def options_name(item: dict) -> str:
    return item["tag"] + operation_name(item["operation"], item["path"]).removesuffix("Async") + "Options"


def is_useful_query(item: dict, parameter: dict) -> bool:
    name = parameter.get("name")
    return name not in EXCLUDED_QUERY_PARAMETERS and (item["path"], name) not in EXCLUDED_QUERY_PARAMETERS_BY_PATH


def optional_queries(item: dict) -> list[dict]:
    path_names = set(re.findall(r"{([^}]+)}", item["path"]))
    return [p for p in item["operation"].get("parameters", []) if p.get("in") == "query" and not p.get("required") and not p.get("deprecated") and is_useful_query(item, p) and p.get("name") not in path_names]


def required_queries(item: dict) -> list[dict]:
    return [p for p in item["operation"].get("parameters", []) if p.get("in") == "query" and p.get("required") and not p.get("deprecated") and is_useful_query(item, p)]


def generate_options(operations: list[dict]) -> str:
    lines = ["// <auto-generated />", "#nullable enable", "using System.Runtime.Serialization;", "", "namespace Mvx.ApiClient.Net.Requests.Api;", ""]
    emitted_enums: set[str] = set()
    for item in operations:
        queries = optional_queries(item)
        if not queries:
            continue
        name = options_name(item)
        lines += [f"/// <summary>Optional filters for {item['path']}.</summary>", f"public sealed class {name}", "{"]
        pagination_names = {p["name"] for p in queries} & {"from", "size"}
        if pagination_names == {"from", "size"}:
            lines += ["    /// <summary>Gets or sets pagination for the request.</summary>", "    public Pagination? Pagination { get; init; }", ""]
        for parameter in queries:
            if parameter["name"] in {"from", "size"} and pagination_names == {"from", "size"}:
                continue
            values = query_enum_values(parameter)
            enum_name = f"{name}{pascal(parameter['name'])}" if values else None
            prop_type = query_type(parameter, enum_name)
            lines += [f"    /// <summary>Gets or sets the <c>{parameter['name']}</c> filter.</summary>", f"    public {prop_type} {pascal(parameter['name'])} {{ get; init; }}", ""]
            if enum_name:
                emitted_enums.add(enum_name)
        lines += ["}", ""]
        for parameter in queries:
            values = query_enum_values(parameter)
            if not values:
                continue
            enum_name = f"{name}{pascal(parameter['name'])}"
            lines += [f"/// <summary>Known values for the <c>{parameter['name']}</c> filter on {item['path']}.</summary>", f"public enum {enum_name}", "{", "    /// <summary>No supported filter value was selected.</summary>", "    Unknown = 0,"]
            for index, value in enumerate(values, 1):
                lines += [f"    /// <summary>The upstream <c>{value or '(empty)'}</c> value.</summary>", f"    [EnumMember(Value = \"{value}\")]", f"    {enum_member(value)} = {index},"]
            lines += ["}", ""]
    return "\n".join(lines)


def method_parameters(item: dict, include_defaults: bool = True) -> list[tuple[str, str, str]]:
    params: list[tuple[str, str, str]] = []
    path_names = set(re.findall(r"{([^}]+)}", item["path"]))
    for parameter in item["operation"].get("parameters", []):
        if parameter.get("in") != "path":
            continue
        schema = query_schema(parameter)
        ptype = "long" if schema.get("type") in {"number", "integer"} else "string"
        params.append((ptype, camel(parameter["name"]), parameter["name"]))
    for parameter in required_queries(item):
        if parameter["name"] in path_names:
            continue
        enum_name = f"{operation_name(item['operation'], item['path']).removesuffix('Async')}Required{pascal(parameter['name'])}" if query_enum_values(parameter) else None
        params.append((query_type(parameter, enum_name).rstrip("?"), camel(parameter["name"]), parameter["name"]))
    if optional_queries(item):
        default = " = null" if include_defaults else ""
        params.append((f"{options_name(item)}?", "options" + default, "options"))
    default = " = default" if include_defaults else ""
    params.append(("CancellationToken", "cancellationToken" + default, "cancellationToken"))
    return params


def signature(item: dict, include_defaults: bool = True) -> str:
    result, _ = response_type(item["operation"], item["path"])
    parameters = ", ".join(f"{ptype} {name}" for ptype, name, _ in method_parameters(item, include_defaults))
    return f"Task<{result}> {operation_name(item['operation'], item['path'])}({parameters})"


def generate_interfaces(operations: list[dict]) -> str:
    lines = [
        "// <auto-generated />", "#nullable enable", "using System.Text.Json;", "using Mvx.ApiClient.Net.Models.Api;",
        "using Mvx.ApiClient.Net.Requests.Api;", "", "namespace Mvx.ApiClient.Net;", ""
    ]
    grouped: dict[str, list[dict]] = {}
    for item in operations:
        if item["path"] in EXISTING_PATHS:
            continue
        grouped.setdefault(item["tag"], []).append(item)
    for tag, items in grouped.items():
        partial = " partial" if tag in {"Network", "XExchange"} else ""
        lines += [f"/// <summary>Client for MultiversX {tag} GET endpoints.</summary>", f"public{partial} interface I{tag}Client", "{"]
        for item in items:
            lines += [f"    /// <summary>{item['operation'].get('summary', 'Gets data from the MultiversX API.')}.</summary>"]
            for ptype, name, original in method_parameters(item):
                clean = name.split(" ", 1)[0]
                lines += [f"    /// <param name=\"{clean}\">{('A token that can cancel the request.' if original == 'cancellationToken' else 'The ' + original + ' value.')}</param>"]
            lines += ["    /// <returns>The response returned by the MultiversX API.</returns>", f"    {signature(item)};", ""]
        lines += ["}", ""]
    lines += ["/// <summary>Generated endpoint groups on the root MultiversX client.</summary>", "public partial interface IMvxApiClient", "{"]
    for tag in grouped:
        if tag in {"Network", "XExchange"}:
            continue
        lines += [f"    /// <summary>Gets the {tag} endpoint client.</summary>", f"    I{tag}Client {tag} {{ get; }}", ""]
    lines += ["}", ""]
    return "\n".join(lines)


def query_build_lines(item: dict) -> list[str]:
    optional = optional_queries(item)
    required = required_queries(item)
    path_names = set(re.findall(r"{([^}]+)}", item["path"]))
    path_queries = [
        p for p in item["operation"].get("parameters", [])
        if p.get("in") == "query" and p.get("name") in path_names and not p.get("deprecated") and is_useful_query(item, p)
    ]
    if not optional and not required and not path_queries:
        return ["        QueryParameters? query = null;"]
    lines = ["        var query = new QueryParameters();"]
    pagination_names = {p["name"] for p in optional} & {"from", "size"}
    if pagination_names == {"from", "size"}:
        lines.append("        query.AddPagination(options?.Pagination);")
    for parameter in path_queries:
        name = parameter["name"]
        lines.append(f"        query.AddString(\"{name}\", {camel(name)});")
    for parameter in required:
        name = parameter["name"]
        if name in EXCLUDED_QUERY_PARAMETERS:
            continue
        source = camel(name)
        if name in path_names:
            continue
        values = query_enum_values(parameter)
        kind = query_schema(parameter).get("type")
        if values:
            lines.append(f"        query.AddEnum(\"{name}\", {source});")
        elif kind == "boolean":
            lines.append(f"        query.AddBoolean(\"{name}\", {source});")
        elif kind in {"number", "integer"}:
            lines.append(f"        query.AddNumber(\"{name}\", {source});")
        elif kind == "array":
            lines.append(f"        query.AddCollection(\"{name}\", {source});")
        else:
            lines.append(f"        query.AddString(\"{name}\", {source});")
    for parameter in optional:
        name = parameter["name"]
        if name in {"from", "size"} and pagination_names == {"from", "size"}:
            continue
        prop = f"options?.{pascal(name)}"
        values = query_enum_values(parameter)
        kind = query_schema(parameter).get("type")
        if values and kind == "array":
            lines.append(f"        query.AddEnumCollection(\"{name}\", {prop});")
        elif values:
            lines.append(f"        query.AddOptionalEnum(\"{name}\", {prop});")
        elif kind == "boolean":
            lines.append(f"        query.AddBoolean(\"{name}\", {prop});")
        elif kind in {"number", "integer"}:
            lines.append(f"        query.AddOptionalNumber(\"{name}\", {prop});")
        elif kind == "array":
            lines.append(f"        query.AddCollection(\"{name}\", {prop});")
        else:
            lines.append(f"        query.AddString(\"{name}\", {prop});")
    return lines


def path_expression(path: str) -> str:
    relative = path.lstrip("/")
    names = re.findall(r"{([^}]+)}", relative)
    if not names:
        return f'"{relative}"'
    expression = relative
    for name in names:
        expression = expression.replace("{" + name + "}", "{" + f"ApiPath.EscapeRequired({camel(name)}.ToString(), nameof({camel(name)}))" + "}")
    return '$"' + expression + '"'


def generate_clients(operations: list[dict]) -> str:
    lines = [
        "// <auto-generated />", "#nullable enable", "using System.Text.Json;", "using Mvx.ApiClient.Net.Infrastructure;",
        "using Mvx.ApiClient.Net.Models.Api;", "using Mvx.ApiClient.Net.Requests.Api;", "", "namespace Mvx.ApiClient.Net.Clients;", ""
    ]
    grouped: dict[str, list[dict]] = {}
    for item in operations:
        if item["path"] in EXISTING_PATHS:
            continue
        grouped.setdefault(item["tag"], []).append(item)
    for tag, items in grouped.items():
        if tag in {"Network", "XExchange"}:
            lines += [f"internal sealed partial class {tag}Client", "{"]
        else:
            lines += [f"internal sealed class {tag}Client : I{tag}Client", "{", "    private readonly ApiRequestExecutor _requestExecutor;", "", f"    public {tag}Client(HttpClient httpClient)", "    {", "        _requestExecutor = new ApiRequestExecutor(httpClient);", "    }", ""]
        for item in items:
            result, mode = response_type(item["operation"], item["path"])
            params = ", ".join(f"{ptype} {name}" for ptype, name, _ in method_parameters(item))
            lines += [f"    [ApiOperation(\"{item['path']}\", \"{item['operation'].get('operationId', '')}\")]", f"    public async Task<{result}> {operation_name(item['operation'], item['path'])}({params})", "    {", f"        var path = {path_expression(item['path'])};"]
            lines += query_build_lines(item)
            call = {"json": f"GetJsonAsync<{result}>", "string": "GetStringAsync", "content": "GetContentAsync", "number": "GetInt64Async"}[mode]
            lines += [f"        return await _requestExecutor.{call}(path, query, cancellationToken);", "    }", ""]
        lines += ["}", ""]
    return "\n".join(lines)


def generate_registration(operations: list[dict], source_sha256: str) -> str:
    tags = []
    for item in operations:
        if item["path"] in EXISTING_PATHS or item["tag"] in {"Network", "XExchange"}:
            continue
        if item["tag"] not in tags:
            tags.append(item["tag"])
    lines = ["// <auto-generated />", "#nullable enable", "using Microsoft.Extensions.DependencyInjection;", "", "namespace Mvx.ApiClient.Net.Clients;", "", "internal static class GeneratedApiRegistration", "{", f"    internal const string SourceSha256 = \"{source_sha256}\";", "", "    internal static void Register(IServiceCollection services, Uri baseAddress, MvxApiClientOptions options)", "    {"]
    for tag in tags:
        lines.append(f"        ServiceCollectionExtensions.RegisterClient<I{tag}Client, {tag}Client>(services, baseAddress, options);")
    lines += ["    }", "}", "", "internal sealed partial class MvxApiClient", "{"]
    for tag in tags:
        lines += [f"    public I{tag}Client {tag} {{ get; private set; }} = null!;", ""]
    lines += ["    private void InitializeGeneratedClients(IServiceProvider provider)", "    {"]
    for tag in tags:
        lines.append(f"        {tag} = provider.GetRequiredService<I{tag}Client>();")
    lines += ["    }", "}", ""]
    return "\n".join(lines)


def main() -> None:
    parser = argparse.ArgumentParser()
    parser.add_argument("spec", type=Path, nargs="?", default=Path(__file__).with_name("multiversx-openapi.json"))
    parser.add_argument("--root", type=Path, default=Path(__file__).resolve().parents[1])
    args = parser.parse_args()
    source_bytes = args.spec.read_bytes()
    source_sha256 = hashlib.sha256(source_bytes).hexdigest()
    spec = json.loads(source_bytes.decode("utf-8-sig"))
    operations = load_operations(spec)
    output = args.root / "src" / "Mvx.ApiClient.Net" / "Generated"
    output.mkdir(parents=True, exist_ok=True)
    files = {
        "ApiModels.g.cs": generate_models(spec, operations),
        "ApiQueryOptions.g.cs": generate_options(operations),
        "ApiClients.g.cs": generate_interfaces(operations),
        "ApiClientImplementations.g.cs": generate_clients(operations),
        "ApiRegistration.g.cs": generate_registration(operations, source_sha256),
    }
    for name, content in files.items():
        (output / name).write_text(content.rstrip() + "\n", encoding="utf-8", newline="\n")
    print(f"Generated {len(operations)} non-deprecated GET operations across {len(files)} files.")


if __name__ == "__main__":
    main()
