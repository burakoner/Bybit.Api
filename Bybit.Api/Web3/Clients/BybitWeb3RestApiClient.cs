namespace Bybit.Api.Web3;

/// <summary>
/// Bybit REST API Web3 client.
/// </summary>
public class BybitWeb3RestApiClient
{
    private const string _v5AlphaTradeQuote = "v5/alpha/trade/quote";
    private const string _v5AlphaTradePurchase = "v5/alpha/trade/purchase";
    private const string _v5AlphaTradeRedeem = "v5/alpha/trade/redeem";
    private const string _v5AlphaTradePayTokenList = "v5/alpha/trade/pay-token-list";
    private const string _v5AlphaTradeOrderList = "v5/alpha/trade/order-list";
    private const string _v5AlphaTradeBizTokenList = "v5/alpha/trade/biz-token-list";
    private const string _v5AlphaTradeBizTokenPriceList = "v5/alpha/trade/biz-token-price-list";
    private const string _v5AlphaTradeBizTokenDetails = "v5/alpha/trade/biz-token-details";
    private const string _v5AlphaTradeAssetList = "v5/alpha/trade/asset-list";
    private const string _v5AlphaTradeAssetDetail = "v5/alpha/trade/asset-detail";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitWeb3RestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get a price quote before executing a purchase or redeem trade.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3TradeQuote>> GetTradeQuoteAsync(
        BybitWeb3TradeType tradeType,
        string fromTokenCode,
        decimal fromTokenAmount,
        string toTokenCode,
        BybitWeb3QuoteMode? quoteMode = null,
        CancellationToken ct = default)
    {
        return GetTradeQuoteAsync(new BybitWeb3TradeQuoteRequest(tradeType, fromTokenCode, fromTokenAmount, toTokenCode)
        {
            QuoteMode = quoteMode,
        }, ct);
    }

    /// <summary>
    /// Get a price quote before executing a purchase or redeem trade.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3TradeQuote>> GetTradeQuoteAsync(BybitWeb3TradeQuoteRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateTradeType(request.TradeType, allowAll: false, nameof(request.TradeType));
        ValidateRequired(request.FromTokenCode, nameof(request.FromTokenCode));
        ValidateRequired(request.ToTokenCode, nameof(request.ToTokenCode));
        ValidatePositive(request.FromTokenAmount, nameof(request.FromTokenAmount));

        var parameters = new ParameterCollection
        {
            { "tradeType", (int)request.TradeType },
            { "fromTokenCode", request.FromTokenCode },
            { "toTokenCode", request.ToTokenCode },
        };
        parameters.AddString("fromTokenAmount", request.FromTokenAmount);
        AddOptionalIntegerEnum(parameters, "quoteMode", request.QuoteMode);

        return await _.SendBybitRequest<BybitWeb3TradeQuote>(_.BuildUri(_v5AlphaTradeQuote), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Execute a buy trade to purchase on-chain tokens using payment tokens.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3TradeExecution>> ExecutePurchaseAsync(
        string fromTokenCode,
        decimal fromTokenAmount,
        string toTokenCode,
        decimal slippage,
        string quoteData,
        decimal gas,
        BybitWeb3QuoteMode quoteMode,
        string correctingCode,
        string? tenant = null,
        CancellationToken ct = default)
    {
        return ExecutePurchaseAsync(new BybitWeb3PurchaseRequest(fromTokenCode, fromTokenAmount, toTokenCode, slippage, quoteData, gas, quoteMode, correctingCode)
        {
            Tenant = tenant,
        }, ct);
    }

    /// <summary>
    /// Execute a buy trade to purchase on-chain tokens using payment tokens.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3TradeExecution>> ExecutePurchaseAsync(BybitWeb3PurchaseRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateExecuteRequest(request.FromTokenCode, request.FromTokenAmount, request.ToTokenCode, request.Slippage, request.QuoteData, request.Gas, request.CorrectingCode);

        var parameters = CreateExecuteTradeParameters(request.FromTokenCode, request.FromTokenAmount, request.ToTokenCode, request.Slippage, request.QuoteData, request.Gas, request.QuoteMode, request.CorrectingCode, request.Tenant);
        return await _.SendBybitRequest<BybitWeb3TradeExecution>(_.BuildUri(_v5AlphaTradePurchase), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Execute a sell trade to redeem on-chain tokens back to payment tokens.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3TradeExecution>> ExecuteRedeemAsync(
        string fromTokenCode,
        decimal fromTokenAmount,
        string toTokenCode,
        decimal slippage,
        string quoteData,
        decimal gas,
        BybitWeb3QuoteMode quoteMode,
        string correctingCode,
        string? tenant = null,
        CancellationToken ct = default)
    {
        return ExecuteRedeemAsync(new BybitWeb3RedeemRequest(fromTokenCode, fromTokenAmount, toTokenCode, slippage, quoteData, gas, quoteMode, correctingCode)
        {
            Tenant = tenant,
        }, ct);
    }

    /// <summary>
    /// Execute a sell trade to redeem on-chain tokens back to payment tokens.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3TradeExecution>> ExecuteRedeemAsync(BybitWeb3RedeemRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateExecuteRequest(request.FromTokenCode, request.FromTokenAmount, request.ToTokenCode, request.Slippage, request.QuoteData, request.Gas, request.CorrectingCode);

        var parameters = CreateExecuteTradeParameters(request.FromTokenCode, request.FromTokenAmount, request.ToTokenCode, request.Slippage, request.QuoteData, request.Gas, request.QuoteMode, request.CorrectingCode, request.Tenant);
        return await _.SendBybitRequest<BybitWeb3TradeExecution>(_.BuildUri(_v5AlphaTradeRedeem), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query available payment tokens.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitWeb3PaymentToken>>> GetPaymentTokensAsync(string chainCode, string tokenAddress, CancellationToken ct = default)
        => GetPaymentTokensAsync(new BybitWeb3PaymentTokenListRequest(chainCode, tokenAddress), ct);

    /// <summary>
    /// Query available payment tokens.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitWeb3PaymentToken>>> GetPaymentTokensAsync(BybitWeb3PaymentTokenListRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateRequired(request.ChainCode, nameof(request.ChainCode));
        ValidateRequired(request.TokenAddress, nameof(request.TokenAddress));

        var parameters = new ParameterCollection
        {
            { "chainCode", request.ChainCode },
            { "tokenAddress", request.TokenAddress },
        };

        return await _.SendBybitRequest<List<BybitWeb3PaymentToken>>(_.BuildUri(_v5AlphaTradePayTokenList), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query user's on-chain trade order history.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3OrderResult>> GetOrdersAsync(
        int limit,
        int pageIndex,
        BybitWeb3TradeType? tradeType = null,
        string? tokenCode = null,
        IEnumerable<BybitWeb3OrderStatus>? orderStatus = null,
        int? days = null,
        BybitWeb3PaginationDirection? direction = null,
        CancellationToken ct = default)
    {
        return GetOrdersAsync(new BybitWeb3OrderListRequest(limit, pageIndex)
        {
            TradeType = tradeType,
            TokenCode = tokenCode,
            OrderStatus = orderStatus == null ? null : [.. orderStatus],
            Days = days,
            Direction = direction,
        }, ct);
    }

    /// <summary>
    /// Query user's on-chain trade order history.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3OrderResult>> GetOrdersAsync(BybitWeb3OrderListRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.Limit.ValidateIntBetween(nameof(request.Limit), 1, 100);
        request.PageIndex.ValidateIntBetween(nameof(request.PageIndex), 1, int.MaxValue);
        request.Days?.ValidateIntBetween(nameof(request.Days), 0, 90);
        if (request.TradeType.HasValue) ValidateTradeType(request.TradeType.Value, allowAll: true, nameof(request.TradeType));
        if (request.OrderStatus != null && request.OrderStatus.Count == 0) throw new ArgumentException("Order status list cannot be empty.", nameof(request));

        var parameters = new ParameterCollection
        {
            { "limit", request.Limit },
            { "pageIndex", request.PageIndex },
        };
        AddOptionalIntegerEnum(parameters, "tradeType", request.TradeType);
        parameters.AddOptional("tokenCode", request.TokenCode);
        if (request.OrderStatus != null) parameters.Add("orderStatus", request.OrderStatus.Select(x => (int)x).ToList());
        parameters.AddOptional("days", request.Days);
        AddOptionalDirection(parameters, request.Direction);

        return await _.SendBybitRequest<BybitWeb3OrderResult>(_.BuildUri(_v5AlphaTradeOrderList), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query the list of on-chain tokens available for trading.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitWeb3BizToken>>> GetBizTokensAsync(BybitWeb3TokenTagFilter? tokenTag = null, CancellationToken ct = default)
        => GetBizTokensAsync(new BybitWeb3BizTokenListRequest { TokenTag = tokenTag }, ct);

    /// <summary>
    /// Query the list of on-chain tokens available for trading.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitWeb3BizToken>>> GetBizTokensAsync(BybitWeb3BizTokenListRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var parameters = new ParameterCollection();
        AddOptionalIntegerEnum(parameters, "tokenTag", request.TokenTag);

        return await _.SendBybitRequest<List<BybitWeb3BizToken>>(_.BuildUri(_v5AlphaTradeBizTokenList), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Batch query on-chain token prices.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3TokenPriceList>> GetTokenPricesAsync(IEnumerable<BybitWeb3TokenAddressInfo> tokenAddressInfo, CancellationToken ct = default)
        => GetTokenPricesAsync(new BybitWeb3TokenPriceListRequest(tokenAddressInfo), ct);

    /// <summary>
    /// Query a single on-chain token price.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3TokenPriceList>> GetTokenPricesAsync(string chainCode, string tokenAddress, CancellationToken ct = default)
        => GetTokenPricesAsync([new BybitWeb3TokenAddressInfo(chainCode, tokenAddress)], ct);

    /// <summary>
    /// Batch query on-chain token prices.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3TokenPriceList>> GetTokenPricesAsync(BybitWeb3TokenPriceListRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateTokenAddressInfo(request.TokenAddressInfo);

        var parameters = new ParameterCollection
        {
            { "tokenAddressInfo", request.TokenAddressInfo },
        };

        return await _.SendBybitRequest<BybitWeb3TokenPriceList>(_.BuildUri(_v5AlphaTradeBizTokenPriceList), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query detailed information for a specific on-chain token.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3TokenDetails>> GetTokenDetailsAsync(string chainCode, string tokenAddress, CancellationToken ct = default)
        => GetTokenDetailsAsync(new BybitWeb3TokenDetailsRequest(chainCode, tokenAddress), ct);

    /// <summary>
    /// Query detailed information for a specific on-chain token.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3TokenDetails>> GetTokenDetailsAsync(BybitWeb3TokenDetailsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateRequired(request.ChainCode, nameof(request.ChainCode));
        ValidateRequired(request.TokenAddress, nameof(request.TokenAddress));

        var parameters = new ParameterCollection
        {
            { "chainCode", request.ChainCode },
            { "tokenAddress", request.TokenAddress },
        };

        return await _.SendBybitRequest<BybitWeb3TokenDetails>(_.BuildUri(_v5AlphaTradeBizTokenDetails), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query user's on-chain token portfolio.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3AssetList>> GetAssetsAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitWeb3AssetList>(_.BuildUri(_v5AlphaTradeAssetList), HttpMethod.Post, ct, true, bodyParameters: new ParameterCollection()).ConfigureAwait(false);

    /// <summary>
    /// Query detailed holding information for a specific on-chain token.
    /// </summary>
    public Task<BybitRestCallResult<BybitWeb3AssetDetail>> GetAssetDetailAsync(string chainCode, string tokenAddress, CancellationToken ct = default)
        => GetAssetDetailAsync(new BybitWeb3AssetDetailRequest(chainCode, tokenAddress), ct);

    /// <summary>
    /// Query detailed holding information for a specific on-chain token.
    /// </summary>
    public async Task<BybitRestCallResult<BybitWeb3AssetDetail>> GetAssetDetailAsync(BybitWeb3AssetDetailRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateRequired(request.ChainCode, nameof(request.ChainCode));
        ValidateRequired(request.TokenAddress, nameof(request.TokenAddress));

        var parameters = new ParameterCollection
        {
            { "chainCode", request.ChainCode },
            { "tokenAddress", request.TokenAddress },
        };

        return await _.SendBybitRequest<BybitWeb3AssetDetail>(_.BuildUri(_v5AlphaTradeAssetDetail), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    private static ParameterCollection CreateExecuteTradeParameters(
        string fromTokenCode,
        decimal fromTokenAmount,
        string toTokenCode,
        decimal slippage,
        string quoteData,
        decimal gas,
        BybitWeb3QuoteMode quoteMode,
        string correctingCode,
        string? tenant)
    {
        var parameters = new ParameterCollection
        {
            { "fromTokenCode", fromTokenCode },
            { "toTokenCode", toTokenCode },
            { "quoteData", quoteData },
            { "quoteMode", (int)quoteMode },
            { "correctingCode", correctingCode },
        };
        parameters.AddString("fromTokenAmount", fromTokenAmount);
        parameters.AddString("slippage", slippage);
        parameters.AddString("gas", gas);
        parameters.AddOptional("tenant", tenant);

        return parameters;
    }

    private static void ValidateExecuteRequest(string fromTokenCode, decimal fromTokenAmount, string toTokenCode, decimal slippage, string quoteData, decimal gas, string correctingCode)
    {
        ValidateRequired(fromTokenCode, nameof(fromTokenCode));
        ValidateRequired(toTokenCode, nameof(toTokenCode));
        ValidateRequired(quoteData, nameof(quoteData));
        ValidateRequired(correctingCode, nameof(correctingCode));
        ValidatePositive(fromTokenAmount, nameof(fromTokenAmount));
        ValidateMinimum(slippage, nameof(slippage), 0m);
        ValidateMinimum(gas, nameof(gas), 0m);
    }

    private static void ValidateTokenAddressInfo(ICollection<BybitWeb3TokenAddressInfo> tokenAddressInfo)
    {
        if (tokenAddressInfo == null) throw new ArgumentNullException(nameof(tokenAddressInfo));
        tokenAddressInfo.Count.ValidateIntBetween(nameof(tokenAddressInfo), 1, 20);

        foreach (var item in tokenAddressInfo)
        {
            if (item == null) throw new ArgumentException("Token address info cannot contain null items.", nameof(tokenAddressInfo));
            ValidateRequired(item.ChainCode, nameof(item.ChainCode));
            ValidateRequired(item.TokenAddress, nameof(item.TokenAddress));
        }
    }

    private static void ValidateTradeType(BybitWeb3TradeType tradeType, bool allowAll, string name)
    {
        if (!allowAll && tradeType == BybitWeb3TradeType.All)
            throw new ArgumentException("Trade type must be purchase or redeem.", name);

        if (tradeType is not (BybitWeb3TradeType.All or BybitWeb3TradeType.Purchase or BybitWeb3TradeType.Redeem))
            throw new ArgumentException("Unsupported trade type.", name);
    }

    private static void ValidateRequired(string? value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{name} is required.", name);
    }

    private static void ValidatePositive(decimal value, string name)
    {
        if (value <= 0)
            throw new ArgumentException($"{name} must be greater than 0.", name);
    }

    private static void ValidateMinimum(decimal value, string name, decimal minimum)
    {
        if (value < minimum)
            throw new ArgumentException($"{name} must be greater than or equal to {minimum.ToString(CultureInfo.InvariantCulture)}.", name);
    }

    private static void AddOptionalIntegerEnum<T>(ParameterCollection parameters, string name, T? value) where T : struct, Enum
    {
        if (value.HasValue)
            parameters.Add(name, Convert.ToInt32(value.Value, CultureInfo.InvariantCulture));
    }

    private static void AddOptionalDirection(ParameterCollection parameters, BybitWeb3PaginationDirection? direction)
    {
        if (!direction.HasValue)
            return;

        parameters.Add("direction", direction.Value == BybitWeb3PaginationDirection.Previous ? "prev" : "next");
    }
}
