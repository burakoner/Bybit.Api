namespace Bybit.Api.Enums;

/// <summary>
/// Bybit API Key Type
/// </summary>
public enum BybitApiKeyType
{
    /// <summary>
    /// Personal
    /// </summary>
    [Label("1")]
    Personal,

    /// <summary>
    /// Connected to the third-party app
    /// </summary>
    [Label("2")]
    ConnectedToTheThirdPartyApp,
}