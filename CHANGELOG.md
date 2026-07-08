# CHANGELOG

## Unreleased

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
