namespace Mvx.ApiClient.Models.Network;

/// <summary>
/// General information about API deployment
/// </summary>
/// <param name="AppVersion"></param>
/// <param name="PluginsVersion"></param>
/// <param name="Network"></param>
/// <param name="Cluster"></param>
/// <param name="Version"></param>
/// <param name="IndexerVersion"></param>
/// <param name="GatewayVersion"></param>
/// <param name="ScamEngineVersion"></param>
/// <param name="Features"></param>
public record About
(
    string? AppVersion,
    string? PluginsVersion,
    string Network,
    string Cluster,
    string Version,
    string IndexerVersion,
    string GatewayVersion,
    string ScamEngineVersion,
    Features? Features
);