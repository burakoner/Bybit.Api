using Bybit.Api.Models.Trading;

namespace Bybit.Api.Clients.RestApi;

public class BybitPositionRestApiClient
{
    // Position Endpoints
    protected const string v5PositionListEndpoint = "v5/position/list";
    protected const string v5PositionSetLeverageEndpoint = "v5/position/set-leverage";
    protected const string v5PositionSwitchIsolatedEndpoint = "v5/position/switch-isolated";
    protected const string v5PositionSetTpslModeEndpoint = "v5/position/set-tpsl-mode";
    protected const string v5PositionSwitchModeEndpoint = "v5/position/switch-mode";
    protected const string v5PositionSetRiskLimitEndpoint = "v5/position/set-risk-limit"; // Deprecated
    protected const string v5PositionTradingStopEndpoint = "v5/position/trading-stop";
    protected const string v5PositionSetAutoAddMarginEndpoint = "v5/position/set-auto-add-margin";
    protected const string v5PositionAddMarginEndpoint = "v5/position/add-margin"; // TODO
    protected const string v5PositionClosedPnlEndpoint = "v5/position/closed-pnl";
    protected const string v5PositionMovePositionsEndpoint = "v5/position/move-positions"; // TODO
    protected const string v5PositionMoveHistoryEndpoint = "v5/position/move-history"; // TODO
    protected const string v5PositionConfirmPendingMmrEndpoint = "v5/position/confirm-pending-mmr"; // TODO

    // Internal
    internal BaseRestApiClient MainClient { get; }
    internal CultureInfo CI { get { return MainClient.CI; } }

    internal BybitPositionRestApiClient(BybitRestApiClient root)
    {
        this.MainClient = root.MainClient;
    }

    #region Position Methods

    public async Task<RestCallResult<IEnumerable<BybitPosition>>> GetPositionsAsync(BybitCategory category, string symbol = null, string baseAsset = null, string settleAsset = null, int? limit = null, string cursor = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse, BybitCategory.Option))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("baseCoin", baseAsset);
        parameters.AddOptionalParameter("settleCoin", settleAsset);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        var result = await MainClient.SendBybitRequest<BybitRestApiListResponse<BybitPosition>>(MainClient.GetUri(v5PositionListEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<IEnumerable<BybitPosition>>(null);
        return result.As(result.Data.Payload);
    }

    public async Task<RestCallResult> SetLeverageAsync(BybitCategory category, string symbol, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "buyLeverage", buyLeverage.ToString(CI) },
            { "sellLeverage", sellLeverage.ToString(CI) }
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSetLeverageEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SwitchCrossIsolatedMarginAsync(BybitCategory category, string symbol, BybitTradeMode tradeMode, decimal buyLeverage, decimal sellLeverage, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "tradeMode", tradeMode.GetLabel() },
            { "buyLeverage", buyLeverage.ToString(CI) },
            { "sellLeverage", sellLeverage.ToString(CI) }
        };

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSwitchIsolatedEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitTakeProfitStopLoss>> SetTakeProfitStopLossModeAsync(BybitCategory category, string symbol, BybitTakeProfitStopLossMode tpSlMode, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "tpSlMode", tpSlMode.GetLabel() },
        };

        return await MainClient.SendBybitRequest<BybitTakeProfitStopLoss>(MainClient.GetUri(v5PositionSetTpslModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SwitchPositionModeAsync(BybitCategory category, BybitPositionMode mode, string symbol = null, string asset = null, CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "mode", mode.GetLabel() },
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("coin", asset);

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSwitchModeEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRiskLimit>> SetRiskLimitAsync(
        BybitCategory category,
        string symbol,
        long riskId,
        BybitPositionIndex? positionIndex = null,
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "riskId", riskId }
        };

        parameters.AddOptionalParameter("positionIdx", positionIndex.GetLabel());

        return await MainClient.SendBybitRequest<BybitRiskLimit>(MainClient.GetUri(v5PositionSetRiskLimitEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetTradingStopAsync(
        BybitCategory category,
        string symbol,
        BybitPositionIndex positionIndex,
        decimal? takeProfit = null,
        decimal? stopLoss = null,
        decimal? trailingStop = null,
        BybitTriggerPrice? takeProfitTrigger = null,
        BybitTriggerPrice? stopLossTrigger = null,
        decimal? activePrice = null,
        decimal? takeProfitQuantity = null,
        decimal? stopLossQuantity = null,
        CancellationToken ct = default)
    {
        if (category.IsNotIn(BybitCategory.Linear, BybitCategory.Inverse))
            throw new NotSupportedException($"{category} is not supported for this endpoint.");

        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "positionIdx", positionIndex.GetLabel() }
        };

        parameters.AddOptionalParameter("takeProfit", takeProfit?.ToString(CI));
        parameters.AddOptionalParameter("stopLoss", stopLoss?.ToString(CI));
        parameters.AddOptionalParameter("trailingStop", trailingStop?.ToString(CI));
        parameters.AddOptionalParameter("tpTriggerBy", takeProfitTrigger?.GetLabel());
        parameters.AddOptionalParameter("slTriggerBy", stopLossTrigger?.GetLabel());
        parameters.AddOptionalParameter("activePrice", activePrice?.ToString(CI));
        parameters.AddOptionalParameter("tpSize", takeProfitQuantity?.ToString(CI));
        parameters.AddOptionalParameter("slSize", stopLossQuantity?.ToString(CI));

        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionTradingStopEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult> SetAutoAddMarginAsync(
        BybitCategory category,
        string symbol,
        bool autoAddMargin,
        BybitPositionIndex? positionIndex = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>()
        {
            { "category", category.GetLabel() },
            { "symbol", symbol },
            { "autoAddMargin", autoAddMargin ? "1" : "0" }
        };

        parameters.AddOptionalParameter("positionIdx", positionIndex?.GetLabel());
        return await MainClient.SendBybitRequest(MainClient.GetUri(v5PositionSetAutoAddMarginEndpoint), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    public async Task<RestCallResult<BybitRestApiCursorResponse<BybitProfitAndLoss>>> GetClosedProfitLossAsync(
        BybitCategory category,
        string symbol = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string cursor = null,
        CancellationToken ct = default)
    {
        var parameters = new Dictionary<string, object>
        {
            { "category", category.GetLabel() },
        };

        parameters.AddOptionalParameter("symbol", symbol);
        parameters.AddOptionalParameter("startTime", startTime);
        parameters.AddOptionalParameter("endTime", endTime);
        parameters.AddOptionalParameter("limit", limit);
        parameters.AddOptionalParameter("cursor", cursor);

        return await MainClient.SendBybitRequest<BybitRestApiCursorResponse<BybitProfitAndLoss>>(MainClient.GetUri(v5PositionClosedPnlEndpoint), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }
    #endregion

}