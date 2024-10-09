namespace Bybit.Api.Enums;

/// <summary>
/// Bybit API Key Type
/// </summary>
public enum BybitApiKeyType
{
    /// <summary>
    /// Personal
    /// </summary>
    [Map("1")]
    Personal = 1,

    /// <summary>
    /// Connected to the third-party app
    /// </summary>
    [Map("2")]
    ConnectedToTheThirdPartyApp = 2,
}