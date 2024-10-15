namespace Mvx.ApiClient.Models.Network;

/// <summary>
/// Network-specific constants
/// </summary>
/// <param name="ChainId">The chain identifier</param>
/// <param name="GasPerDataByte">Gas per data byte</param>
/// <param name="MinGasLimit">Minimum gas limit</param>
/// <param name="MinGasPrice">Minimum gas price</param>
/// <param name="MinTransactionVersion">Minimum transaction version</param>
public record NetworkConstantsDto
(
    string ChainId,
    long GasPerDataByte,
    long MinGasLimit,
    long MinGasPrice,
    int MinTransactionVersion
);