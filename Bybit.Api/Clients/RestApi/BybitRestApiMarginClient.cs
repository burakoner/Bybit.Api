using Bybit.Api.Models.Margin;

namespace Bybit.Api.Clients.RestApi;

/// <summary>
/// Bybit Margin API Client
/// </summary>
public class BybitRestApiMarginClient
{
    // Spot Margin Trade (UTA) Endpoints
    private const string _v5SpotMarginTradeDataMode = "v5/spot-margin-trade/data"; // TODO
    private const string _v5SpotMarginTradeSwitchMode = "v5/spot-margin-trade/switch-mode";
    private const string _v5SpotMarginTradeSetLeverage = "v5/spot-margin-trade/set-leverage";
    private const string _v5SpotMarginTradeDataState = "v5/spot-margin-trade/state"; // TODO

    #region Internal
    internal BybitRestApiBaseClient _ { get; }
    internal BybitRestApiMarginClient(BybitRestApiClient root)
    {
        this._ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Turn on / off spot margin trade
    /// </summary>
    /// <param name="spotMarginMode">1: on, 0: off</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<BybitSpotMarginMode>> ToggleMarginModeAsync(bool spotMarginMode, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection
        {
            { "spotMarginMode", spotMarginMode ? "1" : "0" },
        };

        return await _.SendBybitRequest<BybitSpotMarginMode>(_.BuildUri(_v5SpotMarginTradeSwitchMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Set the user's maximum leverage in spot cross margin
    /// </summary>
    /// <param name="leverage">Leverage. [2, 10]</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult> SetLeverageAsync(decimal leverage, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddString("leverage", leverage);

        return await _.SendBybitRequest(_.BuildUri(_v5SpotMarginTradeSetLeverage), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}