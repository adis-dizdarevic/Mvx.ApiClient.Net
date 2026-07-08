# Contributing

## Local setup

Install the .NET SDK version pinned by `global.json`, then run:

```powershell
dotnet restore Mvx.ApiClient.Net.slnx
dotnet build Mvx.ApiClient.Net.slnx --configuration Release --no-restore
dotnet test Mvx.ApiClient.Net.slnx --configuration Release --no-build
```

## Endpoint groups

New GET endpoint groups should follow the existing structure:

- Add the public interface in `src/Mvx.ApiClient.Net/Abstractions`.
- Add the internal implementation in `src/Mvx.ApiClient.Net/Clients`.
- Add response models in `src/Mvx.ApiClient.Net/Models/<Domain>`.
- Add request paths in `EndpointPaths`.
- Use `ApiRequestExecutor` for HTTP, query encoding, validation, and JSON deserialization.
- Register the client in `ServiceCollectionExtensions`.
- Add HTTP-handler unit tests.
- Update `PublicApi.Shipped.txt` when the public surface changes.

## Test types

Unit tests use fake `HttpMessageHandler` implementations and should not call the public API.

Live API smoke tests live in the integration-test project and only call the public MultiversX API when `MVX_API_LIVE_TESTS=true`.

## Package smoke test

`eng/package-smoke-test.ps1` validates the packed NuGet as a fresh consumer would use it. It creates a temporary console app, restores the local package, and compiles README-style usage.

## Docs

Docs live in `docs/` and are built with Zensical:

```powershell
.\eng\docs.ps1
```

Serve locally:

```powershell
cd docs
..\.venv\Scripts\python.exe -m zensical serve
```
