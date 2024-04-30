namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Leverage Token Status
/// </summary>
public enum BybitLeverageTokenStatus
{
    /// <summary>
    /// LT can be purchased and redeemed
    /// </summary>
    [Label("1")]
    CanBePurchasedAndRedeemed,
    
    /// <summary>
    /// LT can be purchased, but not redeemed
    /// </summary>
    [Label("2")]
    CanBePurchasedButNotRedeemed,
    
    /// <summary>
    /// LT can be redeemed, but not purchased
    /// </summary>
    [Label("3")]
    CanBeRedeemedButNotPurchased,
    
    /// <summary>
    /// LT cannot be purchased nor redeemed
    /// </summary>
    [Label("4")]
    CannotBePurchasedNorRedeemed,
    
    /// <summary>
    /// Adjusting position
    /// </summary>
    [Label("5")]
    AdjustingPosition,
}
