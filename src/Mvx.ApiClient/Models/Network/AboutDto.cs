namespace Mvx.ApiClient.Models.Network;

/// <summary>
/// General information about API deployment
/// </summary>
/// <param name="AppVersion">The current app version</param>
/// <param name="PluginsVersion">The current plugin version</param>
/// <param name="Network">The current network</param>
/// <param name="Cluster">The current cluster</param>
/// <param name="Version">The current version</param>
/// <param name="IndexerVersion">The current indexer version</param>
/// <param name="GatewayVersion">The current gateway version</param>
/// <param name="ScamEngineVersion">The current scam engine version</param>
/// <param name="Features">The current available features</param>
public record AboutDto
(
    string? AppVersion,
    string? PluginsVersion,
    string Network,
    string Cluster,
    string Version,
    string IndexerVersion,
    string GatewayVersion,
    string ScamEngineVersion,
    FeaturesDto? Features
);
