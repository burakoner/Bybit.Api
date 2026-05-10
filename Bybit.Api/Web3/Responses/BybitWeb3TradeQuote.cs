namespace Bybit.Api.Web3;

/// <summary>
/// Web3 trade quote.
/// </summary>
public record BybitWeb3TradeQuote
{
    /// <summary>
    /// Trade type.
    /// </summary>
    public BybitWeb3TradeType TradeType { get; set; }

    /// <summary>
    /// Source token code.
    /// </summary>
    public string FromTokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Amount to pay.
    /// </summary>
    public decimal FromTokenAmount { get; set; }

    /// <summary>
    /// Payment amount in USD.
    /// </summary>
    public decimal? FromTokenAmountUsd { get; set; }

    /// <summary>
    /// Target token code.
    /// </summary>
    public string ToTokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Expected receive amount.
    /// </summary>
    public decimal ToTokenAmount { get; set; }

    /// <summary>
    /// Expected receive amount in USD.
    /// </summary>
    public decimal? ToTokenAmountUsd { get; set; }

    /// <summary>
    /// Minimum amount to receive after slippage.
    /// </summary>
    public decimal? MinToTokenAmount { get; set; }

    /// <summary>
    /// Estimated slippage.
    /// </summary>
    public decimal? Slippage { get; set; }

    /// <summary>
    /// Estimated gas fee in native token unit.
    /// </summary>
    public decimal? Gas { get; set; }

    /// <summary>
    /// Gas fee in USD.
    /// </summary>
    public decimal? GasUsd { get; set; }

    /// <summary>
    /// Platform fee.
    /// </summary>
    public decimal? PlatformFee { get; set; }

    /// <summary>
    /// Platform fee in USD.
    /// </summary>
    public decimal? PlatformFeeUsd { get; set; }

    /// <summary>
    /// Exchange rate.
    /// </summary>
    public decimal? SwapRate { get; set; }

    /// <summary>
    /// Estimated loss rate.
    /// </summary>
    public decimal? LossRate { get; set; }

    /// <summary>
    /// Base64-encoded quote context.
    /// </summary>
    public string QuoteData { get; set; } = string.Empty;

    /// <summary>
    /// Quote checksum.
    /// </summary>
    public string CorrectingCode { get; set; } = string.Empty;

    /// <summary>
    /// Actual quote mode used.
    /// </summary>
    public BybitWeb3QuoteMode QuoteMode { get; set; }

    /// <summary>
    /// Unique quote ID.
    /// </summary>
    public string QuoteDataId { get; set; } = string.Empty;

    /// <summary>
    /// Quote expiration timestamp in milliseconds.
    /// </summary>
    public long? ExpireTime { get; set; }

    /// <summary>
    /// Quote timestamp in milliseconds.
    /// </summary>
    public long? Timestamp { get; set; }

    /// <summary>
    /// Fee charge amount.
    /// </summary>
    public decimal? ChargeAmount { get; set; }

    /// <summary>
    /// Alternative mode estimations.
    /// </summary>
    public List<BybitWeb3ModeEstimation> ModeEstimations { get; set; } = [];
}

/// <summary>
/// Web3 quote mode estimation.
/// </summary>
public record BybitWeb3ModeEstimation
{
    /// <summary>
    /// Quote mode.
    /// </summary>
    public BybitWeb3QuoteMode QuoteMode { get; set; }

    /// <summary>
    /// Estimated gas fee.
    /// </summary>
    public decimal? EstimatedGas { get; set; }

    /// <summary>
    /// Estimated gas fee in USD.
    /// </summary>
    public decimal? EstimatedGasUsd { get; set; }

    /// <summary>
    /// Estimated slippage.
    /// </summary>
    public decimal? EstimatedSlippage { get; set; }
}
