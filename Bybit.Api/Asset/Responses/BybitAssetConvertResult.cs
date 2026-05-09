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
    public string AccountType { get; set; } = string.Empty;
    public string ExchangeTxId { get; set; } = string.Empty;
    public string UserId { get; set; } = string.Empty;
    public string FromCoin { get; set; } = string.Empty;
    public string FromCoinType { get; set; } = string.Empty;
    public string ToCoin { get; set; } = string.Empty;
    public string ToCoinType { get; set; } = string.Empty;
    public decimal FromAmount { get; set; }
    public decimal ToAmount { get; set; }
    public BybitConvertStatus ExchangeStatus { get; set; }
    public BybitAssetConvertExtInfo? ExtInfo { get; set; }
    public decimal ConvertRate { get; set; }
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
    public string ParamType { get; set; } = string.Empty;
    public string ParamValue { get; set; } = string.Empty;
}
