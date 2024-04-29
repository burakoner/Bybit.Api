using Bybit.Api.Models.Margin;

namespace Bybit.Api.Clients.RestApi;

public class BybitRestApiMarginClient
{
    // Spot Margin Trade (UTA) Endpoints
    private const string _v5SpotMarginTradeDataMode = "v5/spot-margin-trade/data"; // TODO
    private const string _v5SpotMarginTradeSwitchMode = "v5/spot-margin-trade/switch-mode";
    private const string _v5SpotMarginTradeSetLeverage = "v5/spot-margin-trade/set-leverage";
    private const string _v5SpotMarginTradeDataState = "v5/spot-margin-trade/state"; // TODO

    #region Internal
    internal BybitRestApiBaseClient MainClient { get; }
    internal BybitRestApiMarginClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }
    #endregion

    public async Task<BybitRestCallResult<BybitSpotMarginMode>> SwitchMarginTradeAsync(bool spotMarginMode, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "spotMarginMode", spotMarginMode ? "1" : "0" },
        };

        return await MainClient.SendBybitRequest<BybitSpotMarginMode>(MainClient.BuildUri(_v5SpotMarginTradeSwitchMode), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<BybitRestCallResult> SetLeverageAsync(decimal leverage, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "leverage", leverage.ToString(BybitConstants.BybitCultureInfo) },
        };

        return await MainClient.SendBybitRequest(MainClient.BuildUri(_v5SpotMarginTradeSetLeverage), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}