# Contributing

## Endpoint groups

New GET endpoint groups should follow the existing structure:

- Add the public interface in `src/Mvx.ApiClient.Net/Abstractions`.
- Add the internal implementation in `src/Mvx.ApiClient.Net/Clients`.
- Add response models in `src/Mvx.ApiClient.Net/Models/<Domain>`.
- Add request paths in `EndpointPaths`.
- Use `ApiRequestExecutor` for HTTP, query encoding, validation, and JSON deserialization.
- Register the client in `ServiceCollectionExtensions`.
- Add HTTP-handler unit tests and update `PublicApi.Shipped.txt` when the public surface changes.

## Test types

Unit tests use fake `HttpMessageHandler` implementations and should not call the public API.

Live API smoke tests live in the integration-test project and only call the public MultiversX API when `MVX_API_LIVE_TESTS=true`.

## Package smoke test

`eng/package-smoke-test.ps1` validates the packed NuGet as a fresh consumer would use it: it creates a temporary console app, restores the local package, and compiles README-style usage.
