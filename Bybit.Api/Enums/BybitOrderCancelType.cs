namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Order Cancel Type
/// </summary>
public enum BybitOrderCancelType
{
    /// <summary>
    /// CancelByUser
    /// </summary>
    [Label("CancelByUser")]
    CancelByUser,

    /// <summary>
    /// CancelByReduceOnly
    /// </summary>
    [Label("CancelByReduceOnly")]
    CancelByReduceOnly,

    /// <summary>
    /// CancelByPrepareLiq
    /// </summary>
    [Label("CancelByPrepareLiq")]
    CancelByPrepareLiq,

    /// <summary>
    /// CancelAllBeforeLiq
    /// </summary>
    [Label("CancelAllBeforeLiq")]
    CancelAllBeforeLiq,

    /// <summary>
    /// CancelByPrepareAdl
    /// </summary>
    [Label("CancelByPrepareAdl")]
    CancelByPrepareAdl,

    /// <summary>
    /// CancelAllBeforeAdl
    /// </summary>
    [Label("CancelAllBeforeAdl")]
    CancelAllBeforeAdl,

    /// <summary>
    /// CancelByAdmin
    /// </summary>
    [Label("CancelByAdmin")]
    CancelByAdmin,

    /// <summary>
    /// CancelByTpSlTsClear
    /// </summary>
    [Label("CancelByTpSlTsClear")]
    CancelByTpSlTsClear,

    /// <summary>
    /// CancelBySmp
    /// </summary>
    [Label("CancelBySmp")]
    CancelBySmp,
}