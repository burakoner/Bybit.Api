namespace Bybit.Api.Account;

/// <summary>
/// Bybit account fee rate request.
/// </summary>
public record BybitAccountFeeRateRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountFeeRateRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitAccountFeeRateRequest(BybitCategory category)
    {
        Category = category;
    }

    /// <summary>
    /// Product type.
    /// </summary>
    public BybitCategory Category { get; set; }

    /// <summary>
    /// Symbol name.
    /// </summary>
    public string? Symbol { get; set; }

    /// <summary>
    /// Base coin. Valid for option.
    /// </summary>
    public string? BaseAsset { get; set; }
}
