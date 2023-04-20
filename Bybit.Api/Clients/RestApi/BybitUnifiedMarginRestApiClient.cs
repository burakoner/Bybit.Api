using Bybit.Api.Models.Margin;

namespace Bybit.Api.Clients.RestApi;

public class BybitUnifiedMarginRestApiClient
{
    // Spot Margin Trade (UTA) Endpoints
    protected const string v5SpotMarginTradeSwitchModeEndpoint = "v5/spot-margin-trade/switch-mode";
    protected const string v5SpotMarginTradeSetLeverageEndpoint = "v5/spot-margin-trade/set-leverage";

    // Internal
    internal BybitBaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitUnifiedMarginRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    public async Task<RestCallResult<BybitSpotMarginMode>> SwitchMarginTradeAsync(bool spotMarginMode, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "spotMarginMode", spotMarginMode ? "1" : "0" },
        };

        return await MainClient.SendBybitRequest<BybitSpotMarginMode>(MainClient.GetUri(v5SpotMarginTradeSwitchModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetLeverageAsync(decimal leverage, CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "leverage", leverage.ToString(CI) },
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5SpotMarginTradeSetLeverageEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

}