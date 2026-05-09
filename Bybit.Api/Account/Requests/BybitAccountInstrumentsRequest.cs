namespace Bybit.Api.Account;

/// <summary>
/// Bybit account instruments request.
/// </summary>
public record BybitAccountInstrumentsRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountInstrumentsRequest"/> record.
    /// </summary>
    /// <param name="category">Product type.</param>
    public BybitAccountInstrumentsRequest(BybitCategory category)
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
    /// Limit for data size per page. Invalid for spot.
    /// </summary>
    public int? Limit { get; set; }

    /// <summary>
    /// Cursor for pagination. Invalid for spot.
    /// </summary>
    public string? Cursor { get; set; }
}
