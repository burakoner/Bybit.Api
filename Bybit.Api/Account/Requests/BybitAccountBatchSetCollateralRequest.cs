namespace Bybit.Api.Account;

/// <summary>
/// Bybit account batch set collateral coin request.
/// </summary>
public record BybitAccountBatchSetCollateralRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitAccountBatchSetCollateralRequest"/> record.
    /// </summary>
    /// <param name="items">Collateral switch items.</param>
    public BybitAccountBatchSetCollateralRequest(IEnumerable<BybitAccountBatchSetCollateralItem> items)
    {
        Items = items.ToList();
    }

    /// <summary>
    /// Collateral switch items.
    /// </summary>
    public List<BybitAccountBatchSetCollateralItem> Items { get; set; } = [];
}
