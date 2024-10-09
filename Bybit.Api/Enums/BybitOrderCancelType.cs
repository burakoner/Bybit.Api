namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Order Cancel Type
/// </summary>
public enum BybitOrderCancelType
{
    /// <summary>
    /// CancelByUser
    /// </summary>
    [Map("CancelByUser")]
    CancelByUser = 1,

    /// <summary>
    /// CancelByReduceOnly
    /// </summary>
    [Map("CancelByReduceOnly")]
    CancelByReduceOnly = 2,

    /// <summary>
    /// CancelByPrepareLiq
    /// </summary>
    [Map("CancelByPrepareLiq")]
    CancelByPrepareLiq = 3,

    /// <summary>
    /// CancelAllBeforeLiq
    /// </summary>
    [Map("CancelAllBeforeLiq")]
    CancelAllBeforeLiq = 4,

    /// <summary>
    /// CancelByPrepareAdl
    /// </summary>
    [Map("CancelByPrepareAdl")]
    CancelByPrepareAdl = 5,

    /// <summary>
    /// CancelAllBeforeAdl
    /// </summary>
    [Map("CancelAllBeforeAdl")]
    CancelAllBeforeAdl = 6,

    /// <summary>
    /// CancelByAdmin
    /// </summary>
    [Map("CancelByAdmin")]
    CancelByAdmin = 7,

    /// <summary>
    /// CancelByTpSlTsClear
    /// </summary>
    [Map("CancelByTpSlTsClear")]
    CancelByTpSlTsClear = 8,

    /// <summary>
    /// CancelBySmp
    /// </summary>
    [Map("CancelBySmp")]
    CancelBySmp = 9,
}