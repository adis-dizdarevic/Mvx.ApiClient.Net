# Endpoint readiness

An upstream GET operation is not automatically ready for this package merely because it appears in Swagger. A public method is added only after its current route, parameters, response representation, and typed model have all been verified.

## Upstream inventory

`eng/multiversx-get-surface.json` is the approved snapshot of the live OpenAPI GET surface. Run the comparison without changing the snapshot:

```powershell
.\eng\api-surface.ps1
```

The snapshot classifies operations as:

- `documented`: the operation has an OpenAPI 200 JSON schema. It is a candidate, not an automatic approval.
- `requires-live-validation`: the success representation is missing or incomplete in OpenAPI. Its response must be characterized before designing a method.
- `excluded`: the operation is upstream-deprecated or an explicitly temporary compatibility alias. It must not be implemented.

The approved July 2026 snapshot contains 145 documented candidates, 12 operations requiring live validation, and 5 excluded operations. CI compares the live contract weekly. After reviewing a legitimate upstream change, update the snapshot explicitly:

```powershell
.\eng\api-surface.ps1 -Update
```

All 157 non-obsolete candidates in this snapshot are implemented in handwritten domain clients. OpenAPI remains an inventory and drift detector; it does not generate public methods, options, or models. `CompleteGetSurfaceTest` compares the reviewed snapshot with the compiled implementation and requires every approved operation ID and path to map exactly once.

The 12 incomplete OpenAPI operations were resolved as follows:

| Operations | Verified representation |
| --- | --- |
| Token logos, provider avatar, identity avatar | Buffered media (`MvxApiContent`) with media type |
| Node versions | JSON dictionary from version to decimal share |
| xExchange counts, account ESDT-history count | Invariant 64-bit integer parsed from scalar text |
| `/hello` | Plain text |
| Transaction batch list/detail | Typed nested batch result from the official API-service entities |

The recurring live suite skips the currently unhealthy `/auctions` and `/auctions/count` routes: mainnet hangs for a bounded list and returns HTTP 500 for `size=0`. Their non-obsolete methods remain locally contract-tested. Source-verification, collection-rank, pool-detail, and batch-detail checks are conditional when no matching live resource exists; the batch detail success model is additionally derived from the official controller/entity source.

## Definition of ready

A GET method is ready only when all of these conditions are met:

1. The operation is present in the current approved snapshot and is not `excluded` or deprecated.
2. Deprecated query parameters are not exposed.
3. The success status, content type, and complete response shape have been confirmed against the live API.
4. Every useful, non-deprecated filter is represented by endpoint-specific options and encoded by the shared query builder.
5. Required path values use the shared path validation and escaping helpers.
6. The response uses the appropriate shared transport mode: typed JSON, text, or buffered content with media metadata.
7. The DTO follows the numeric, optional-field, and enum rules below.
8. Handler-based tests verify the exact path, every query value kind, deserialization, local validation, and representative optional fields.
9. A throttled opt-in mainnet test verifies the live contract.
10. The complete public API snapshot and consumer documentation are updated.

List, detail, and matching count operations should normally be delivered together so their filters and shared models stay consistent.

## Model conventions

- Counts return `long`.
- Atomic blockchain quantities that can exceed 64 bits use `System.Numerics.BigInteger`. The shared serializer accepts either JSON strings or numbers without losing precision.
- Fiat prices, rates, market values, and other bounded fractional values use `decimal`.
- Unix timestamps and high-volume sequence values use `long` unless the upstream contract proves a narrower domain.
- Identifiers, hashes, addresses, and encoded payloads remain strings.
- Fields the API may omit are nullable. The API removes null and empty values from responses, so OpenAPI presence alone is not sufficient evidence that a field is always present.
- Response enums define `Unknown = 0`. New upstream strings deserialize to `Unknown`; outbound query filters reject `Unknown` and use explicit wire names for values that differ from C# names.
- Extra upstream JSON properties are ignored, while malformed values for known properties still fail visibly.

Typed methods deliberately do not expose `fields` or `extract`. Those parameters change the documented response shape and would make non-nullable numeric or Boolean defaults indistinguishable from projected-out values.

## Review rule

Never generate public methods or DTOs blindly from the OpenAPI document. The snapshot is an inventory and drift detector. OpenAPI currently leaves several amount properties and success responses untyped; live evidence and reviewed fixtures remain required.
