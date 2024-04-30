namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Leverage Token Order Status
/// </summary>
public enum BybitLeverageTokenOrderStatus
{
    /// <summary>
    /// Completed
    /// </summary>
    [Label("1")]
    Completed,

    /// <summary>
    /// In Progress
    /// </summary>
    [Label("2")]
    InProgress,

    /// <summary>
    /// Failed
    /// </summary>
    [Label("3")]
    Failed,
}