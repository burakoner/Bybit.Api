namespace Bybit.Api.Web3;

/// <summary>
/// Web3 trade order.
/// </summary>
public record BybitWeb3Order
{
    /// <summary>
    /// Order type.
    /// </summary>
    public BybitWeb3OrderType OrderType { get; set; }

    /// <summary>
    /// Trade type.
    /// </summary>
    public BybitWeb3TradeType TradeType { get; set; }

    /// <summary>
    /// System order number.
    /// </summary>
    public string OrderNo { get; set; } = string.Empty;

    /// <summary>
    /// Order status.
    /// </summary>
    public BybitWeb3OrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Source token code.
    /// </summary>
    public string FromTokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Intended payment amount.
    /// </summary>
    public decimal? FromTokenAmount { get; set; }

    /// <summary>
    /// Source token symbol.
    /// </summary>
    public string FromTokenSymbol { get; set; } = string.Empty;

    /// <summary>
    /// Source token decimal precision.
    /// </summary>
    public int FromTokenDecimals { get; set; }

    /// <summary>
    /// Source token icon URL for light mode.
    /// </summary>
    public string FromTokenIconUrlDay { get; set; } = string.Empty;

    /// <summary>
    /// Source token icon URL for dark mode.
    /// </summary>
    public string FromTokenIconUrlNight { get; set; } = string.Empty;

    /// <summary>
    /// Source chain code.
    /// </summary>
    public string FromChainCode { get; set; } = string.Empty;

    /// <summary>
    /// Source chain icon URL.
    /// </summary>
    public string FromChainIconUrl { get; set; } = string.Empty;

    /// <summary>
    /// Target token code.
    /// </summary>
    public string ToTokenCode { get; set; } = string.Empty;

    /// <summary>
    /// Actual amount received.
    /// </summary>
    public decimal? ToTokenAmount { get; set; }

    /// <summary>
    /// Target token symbol.
    /// </summary>
    public string ToTokenSymbol { get; set; } = string.Empty;

    /// <summary>
    /// Target token decimal precision.
    /// </summary>
    public int ToTokenDecimals { get; set; }

    /// <summary>
    /// Target token icon URL for light mode.
    /// </summary>
    public string ToTokenIconUrlDay { get; set; } = string.Empty;

    /// <summary>
    /// Target token icon URL for dark mode.
    /// </summary>
    public string ToTokenIconUrlNight { get; set; } = string.Empty;

    /// <summary>
    /// Target chain code.
    /// </summary>
    public string ToChainCode { get; set; } = string.Empty;

    /// <summary>
    /// Target chain icon URL.
    /// </summary>
    public string ToChainIconUrl { get; set; } = string.Empty;

    /// <summary>
    /// Native gas token symbol.
    /// </summary>
    public string GasTokenSymbol { get; set; } = string.Empty;

    /// <summary>
    /// On-chain gas fee.
    /// </summary>
    public decimal? GasOnchain { get; set; }

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
    /// Quote mode used.
    /// </summary>
    public BybitWeb3QuoteMode QuoteMode { get; set; }

    /// <summary>
    /// Order creation timestamp in seconds.
    /// </summary>
    public long CreateTime { get; set; }

    /// <summary>
    /// Order creation time.
    /// </summary>
    public DateTime CreateDateTime { get => CreateTime.ConvertFromSeconds(); }

    /// <summary>
    /// Order completion timestamp in seconds.
    /// </summary>
    public long? ExecutionTime { get; set; }

    /// <summary>
    /// Order completion time.
    /// </summary>
    public DateTime? ExecutionDateTime { get => ExecutionTime.HasValue ? ExecutionTime.Value.ConvertFromSeconds() : null; }

    /// <summary>
    /// Failure reason code.
    /// </summary>
    public string FailureReasonCode { get; set; } = string.Empty;

    /// <summary>
    /// Trade source identifier.
    /// </summary>
    public string Source { get; set; } = string.Empty;

    /// <summary>
    /// Actual exchange rate.
    /// </summary>
    public decimal? SwapRate { get; set; }

    /// <summary>
    /// Actual amount paid.
    /// </summary>
    public decimal? ActualFromTokenAmount { get; set; }
}
