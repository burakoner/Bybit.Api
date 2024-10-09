namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Leverage Token Order Status
/// </summary>
public enum BybitLeverageTokenOrderStatus
{
    /// <summary>
    /// Completed
    /// </summary>
    [Map("1")]
    Completed = 1,

    /// <summary>
    /// In Progress
    /// </summary>
    [Map("2")]
    InProgress = 2,

    /// <summary>
    /// Failed
    /// </summary>
    [Map("3")]
    Failed = 3,
}