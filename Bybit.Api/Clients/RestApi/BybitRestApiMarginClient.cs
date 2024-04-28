using Bybit.Api.Models.Margin;

namespace Bybit.Api.Clients.RestApi;

public class BybitRestApiMarginClient
{
    // Spot Margin Trade (UTA) Endpoints
    protected const string v5SpotMarginTradeDataModeEndpoint = "v5/spot-margin-trade/data"; // TODO
    protected const string v5SpotMarginTradeSwitchModeEndpoint = "v5/spot-margin-trade/switch-mode";
    protected const string v5SpotMarginTradeSetLeverageEndpoint = "v5/spot-margin-trade/set-leverage";
    protected const string v5SpotMarginTradeDataStateEndpoint = "v5/spot-margin-trade/state"; // TODO

    // Internal
    internal BybitRestApiBaseClient MainClient { get; }

    internal BybitRestApiMarginClient(BybitRestApiClient root)
    {
        this.MainClient = root.BaseClient;
    }

    public async Task<RestCallResult<BybitSpotMarginMode>> SwitchMarginTradeAsync(bool spotMarginMode, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "spotMarginMode", spotMarginMode ? "1" : "0" },
        };

        return await MainClient.SendBybitRequest<BybitSpotMarginMode>(MainClient.BuildUri(v5SpotMarginTradeSwitchModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetLeverageAsync(decimal leverage, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "leverage", leverage.ToString(BybitConstants.BybitCultureInfo) },
        };

        return await MainClient.SendBybitRequest(MainClient.BuildUri(v5SpotMarginTradeSetLeverageEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}