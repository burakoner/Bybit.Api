namespace Bybit.Api.Enums;

/// <summary>
/// Bybit Leverage Token Status
/// </summary>
public enum BybitLeverageTokenStatus
{
    /// <summary>
    /// LT can be purchased and redeemed
    /// </summary>
    [Map("1")]
    CanBePurchasedAndRedeemed = 1,
    
    /// <summary>
    /// LT can be purchased, but not redeemed
    /// </summary>
    [Map("2")]
    CanBePurchasedButNotRedeemed = 2,
    
    /// <summary>
    /// LT can be redeemed, but not purchased
    /// </summary>
    [Map("3")]
    CanBeRedeemedButNotPurchased = 3,
    
    /// <summary>
    /// LT cannot be purchased nor redeemed
    /// </summary>
    [Map("4")]
    CannotBePurchasedNorRedeemed = 4,
    
    /// <summary>
    /// Adjusting position
    /// </summary>
    [Map("5")]
    AdjustingPosition = 5,
}
