namespace Mvx.ApiClient.Net.Models.Network;

/// <summary>
/// 
/// </summary>
/// <param name="UpdateCollectionExtraDetails">Update Collection extra details flag activation value</param>
/// <param name="Marketplace">Marketplace flag activation value</param>
/// <param name="Exchange">Exchange flag activation value</param>
/// <param name="DataApi">DataApi flag activation value</param>
public record FeaturesDto
(
    bool UpdateCollectionExtraDetails,
    bool Marketplace,
    bool Exchange,
    bool DataApi
);
