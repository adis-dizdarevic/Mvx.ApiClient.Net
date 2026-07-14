# CHANGELOG

## Unreleased

- Implemented all 157 current, non-obsolete MultiversX GET operations across focused clients, including complete endpoint-specific query options and typed JSON, text, count, and media responses.
- Organized every API area as a handwritten singular domain interface and implementation, with domain-scoped request option namespaces and independently maintained response files; OpenAPI is retained only for inventory and drift auditing.
- Added reviewed API response models plus live-evidence corrections for NFT media and owner-history arrays, provider metrics/accounts, account upgrades, NFT thumbnails, node versions, batch results, avatars, logos, and arbitrary-precision balances.
- Added exhaustive operation-to-method and query-wire contract tests, a checked-in approved OpenAPI inventory, and a throttled seeded mainnet suite covering global and parameterized routes.

- Prepared the next breaking release for `2.0.0`.
- Added a reviewed snapshot of the complete upstream GET surface, weekly drift checks, and an automated gate that prevents deprecated or temporary operations from being exposed.
- Added reusable complex-query serialization, secure path construction, JSON/text/binary response modes, arbitrary-precision amount handling, and forward-compatible response enums.
- Replaced the type-name approval test with a complete public API contract snapshot covering members, nullability, defaults, constants, and enum values.
- Expanded throttled opt-in mainnet tests to validate every currently implemented typed GET contract and report disabled live tests as skipped.
- Standardized count endpoint results on `long` and documented the endpoint readiness, numeric, optional-field, and enum policies.
- Removed typed response projections so every typed endpoint returns its complete documented response shape.
- Switched financial response values to `decimal`, preserved optional xExchange pair farm flags, and exposed `Retry-After` on API exceptions.
- Validated client configuration, preserved custom API base paths, and exposed HTTP client builder configuration for resilience and observability.
- Multi-targeted tests, added locked dependency restores, and hardened the release workflow to validate before tagging or publishing.
- Expanded public API contract tests to protect key consumer method and model signatures.
- Migrated the library and tests to .NET 10.
- Switched the test suite to TUnit.
- Added central build and package version management.
- Migrated the solution to `.slnx`.
- Hardened request URI generation, MEX detail endpoints, and API error handling.
- Polished the pre-v1 public API with root namespaces, options-based registration, immutable API exceptions, read-only list results and `net8.0`/`net10.0` multi-targeting.
- Restructured public files by role, renamed the public xExchange API, and centralized request execution.
- Added an opt-in live integration test project gated by `MVX_API_LIVE_TESTS=true`.
- Added stricter library analyzers, a public API baseline file, a package consumer smoke test, and endpoint contribution guidance.
- Replaced the MkDocs documentation layout with a Zensical docs tree under `docs/`.
- Added a `.venv`-based docs build script and fixed the Zensical build command to run from `docs/`.
- Expanded README and Zensical documentation with registration, query option, error handling, client coverage, and release checklist guidance.
- Enforced public XML documentation warnings and filled missing public API documentation details.
- Added contributor, security, issue template, and pull request template governance files.
