# Contributing

Thanks for helping improve Mvx.ApiClient.Net. This project aims to be a small, reliable NuGet package for typed access to public MultiversX API GET endpoints.

## Development setup

Install the .NET SDK pinned by `global.json`, then run:

```powershell
dotnet restore Mvx.ApiClient.Net.slnx
dotnet build Mvx.ApiClient.Net.slnx --configuration Release --no-restore
dotnet test Mvx.ApiClient.Net.slnx --configuration Release --no-build
```

## Quality bar

Before opening a pull request, run:

```powershell
dotnet pack src/Mvx.ApiClient.Net/Mvx.ApiClient.Net.csproj --configuration Release --no-build
.\eng\package-smoke-test.ps1
```

For docs changes:

```powershell
.\eng\docs.ps1
```

## Endpoint contributions

New GET endpoint groups should follow the established layout:

- Public interface in `src/Mvx.ApiClient.Net/Abstractions`.
- Internal implementation in `src/Mvx.ApiClient.Net/Clients`.
- Response models in `src/Mvx.ApiClient.Net/Models/<Domain>`.
- Paths in `EndpointPaths`.
- HTTP execution through `ApiRequestExecutor`.
- DI registration in `ServiceCollectionExtensions`.
- Unit tests using a fake `HttpMessageHandler`.
- Public API baseline update when the public surface changes.

Do not add live public API calls to unit tests. Use the integration-test project and keep live tests disabled unless `MVX_API_LIVE_TESTS=true`.

## Public API changes

The package follows semantic versioning. Public API changes should be intentional and reflected in `tests/Mvx.ApiClient.Net.Test/PublicApi.Shipped.txt`.

Because `1.0.0` has already been released, breaking changes should either keep compatibility aliases or be released as a new major version.

## Commit messages

Use conventional commit messages, for example:

- `feat: add account client`
- `fix: preserve API error response content`
- `docs: expand xExchange examples`
- `test: add live network smoke test`
