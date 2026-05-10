namespace Bybit.Api.Asset;

/// <summary>
/// Bybit convert status response container.
/// </summary>
public record BybitAssetConvertResult
{
    /// <summary>
    /// Convert transaction result.
    /// </summary>
    public BybitAssetConvertTransaction Result { get; set; } = default!;
}

/// <summary>
/// Bybit convert transaction.
/// </summary>
public record BybitAssetConvertTransaction
{
    /// <summary>
    /// Convert wallet type.
    /// </summary>
    public string AccountType { get; set; } = string.Empty;

    /// <summary>
    /// Convert exchange transaction ID.
    /// </summary>
    public string ExchangeTxId { get; set; } = string.Empty;

    /// <summary>
    /// User ID.
    /// </summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Source coin.
    /// </summary>
    public string FromCoin { get; set; } = string.Empty;

    /// <summary>
    /// Source coin account type.
    /// </summary>
    public string FromCoinType { get; set; } = string.Empty;

    /// <summary>
    /// Destination coin.
    /// </summary>
    public string ToCoin { get; set; } = string.Empty;

    /// <summary>
    /// Destination coin account type.
    /// </summary>
    public string ToCoinType { get; set; } = string.Empty;

    /// <summary>
    /// Source coin amount.
    /// </summary>
    public decimal FromAmount { get; set; }

    /// <summary>
    /// Destination coin amount.
    /// </summary>
    public decimal ToAmount { get; set; }

    /// <summary>
    /// Convert transaction status.
    /// </summary>
    public BybitConvertStatus ExchangeStatus { get; set; }

    /// <summary>
    /// Extended convert result information.
    /// </summary>
    public BybitAssetConvertExtInfo? ExtInfo { get; set; }

    /// <summary>
    /// Final convert rate.
    /// </summary>
    public decimal ConvertRate { get; set; }

    /// <summary>
    /// Convert transaction creation timestamp in milliseconds.
    /// </summary>
    public long? CreatedAt { get; set; }

    /// <summary>
    /// Quote creation time.
    /// </summary>
    [JsonIgnore]
    public DateTime? CreatedTime { get => CreatedAt?.ConvertFromMilliseconds(); }
}

/// <summary>
/// Bybit convert extended info.
/// </summary>
public record BybitAssetConvertExtInfo
{
    /// <summary>
    /// Extended parameter type.
    /// </summary>
    public string ParamType { get; set; } = string.Empty;

    /// <summary>
    /// Extended parameter value.
    /// </summary>
    public string ParamValue { get; set; } = string.Empty;
}
