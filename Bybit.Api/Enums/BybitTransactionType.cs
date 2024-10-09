namespace Bybit.Api.Enums;

/// <summary>
/// Bybit transaction type
/// </summary>
public enum BybitTransactionType
{
    /// <summary>
    /// Transfer in
    /// </summary>
    [Map("TRANSFER_IN")]
    TransferIn = 1,

    /// <summary>
    /// Transfer out
    /// </summary>
    [Map("TRANSFER_OUT")]
    TransferOut = 2,

    /// <summary>
    /// Trade
    /// </summary>
    [Map("TRADE")]
    Trade = 3,

    /// <summary>
    /// Settlement
    /// </summary>
    [Map("SETTLEMENT")]
    Settlement = 4,

    /// <summary>
    /// Delivery
    /// </summary>
    [Map("DELIVERY")]
    Delivery = 5,

    /// <summary>
    /// Liquidation
    /// </summary>
    [Map("LIQUIDATION")]
    Liquidation = 6,

    /// <summary>
    /// Auto deleveraging
    /// </summary>
    [Map("ADL")]
    AutoDeleveraging = 7,

    /// <summary>
    /// Airdrop
    /// </summary>
    [Map("AIRDROP")]
    Airdrop = 8,

    /// <summary>
    /// Bonus
    /// </summary>
    [Map("BONUS")]
    Bonus = 9,

    /// <summary>
    /// Bonus expired
    /// </summary>
    [Map("BONUS_RECOLLECT")]
    BonusExpired = 10,

    /// <summary>
    /// Fee refund
    /// </summary>
    [Map("FEE_REFUND")]
    FeeRefund = 11,

    /// <summary>
    /// Interest
    /// </summary>
    [Map("INTEREST")]
    Interest = 12,

    /// <summary>
    /// Currency buy
    /// </summary>
    [Map("CURRENCY_BUY")]
    CurrencyBuy = 13,

    /// <summary>
    /// Currency sell
    /// </summary>
    [Map("CURRENCY_SELL")]
    CurrencySell = 14,

    /// <summary>
    /// InstitutionalLoanBorrowedAmount
    /// </summary>
    [Map("BORROWED_AMOUNT_INS_LOAN")]
    InstitutionalLoanBorrowedAmount = 15,
    
    /// <summary>
    /// InstitutionalLoanPrincipleRepayment
    /// </summary>
    [Map("PRINCIPLE_REPAYMENT_INS_LOAN")]
    InstitutionalLoanPrincipleRepayment = 16,
    
    /// <summary>
    /// InstitutionalLoanInterestRepayment
    /// </summary>
    [Map("INTEREST_REPAYMENT_INS_LOAN")]
    InstitutionalLoanInterestRepayment = 17,
    
    /// <summary>
    /// InstitutionalLoanAutoSoldCollateral
    /// </summary>
    [Map("AUTO_SOLD_COLLATERAL_INS_LOAN")]
    InstitutionalLoanAutoSoldCollateral = 18,
    
    /// <summary>
    /// InstitutionalLoanAutoBuyLiability
    /// </summary>
    [Map("AUTO_BUY_LIABILITY_INS_LOAN")]
    InstitutionalLoanAutoBuyLiability = 19,
    
    /// <summary>
    /// InstitutionalLoanAutoPrincipleRepayment
    /// </summary>
    [Map("AUTO_PRINCIPLE_REPAYMENT_INS_LOAN")]
    InstitutionalLoanAutoPrincipleRepayment = 20,
    
    /// <summary>
    /// InstitutionalLoanAutoInterestRepayment
    /// </summary>
    [Map("AUTO_INTEREST_REPAYMENT_INS_LOAN")]
    InstitutionalLoanAutoInterestRepayment = 21,
    
    /// <summary>
    /// InstitutionalLoanTransferIn
    /// </summary>
    [Map("TRANSFER_IN_INS_LOAN")]
    InstitutionalLoanTransferIn = 22,
    
    /// <summary>
    /// InstitutionalLoanTransferOut
    /// </summary>
    [Map("TRANSFER_OUT_INS_LOAN")]
    InstitutionalLoanTransferOut = 23,
    
    /// <summary>
    /// SpotRepaymentSell
    /// </summary>
    [Map("SPOT_REPAYMENT_SELL")]
    SpotRepaymentSell = 24,
    
    /// <summary>
    /// SpotRepaymentBuy
    /// </summary>
    [Map("SPOT_REPAYMENT_BUY")]
    SpotRepaymentBuy = 25,
    
    /// <summary>
    /// TokensSubscription
    /// </summary>
    [Map("TOKENS_SUBSCRIPTION")]
    TokensSubscription = 26,
    
    /// <summary>
    /// TokensRedemption
    /// </summary>
    [Map("TOKENS_REDEMPTION")]
    TokensRedemption = 27,
    
    /// <summary>
    /// AutoDeduction
    /// </summary>
    [Map("AUTO_DEDUCTION")]
    AutoDeduction = 28,
    
    /// <summary>
    /// FlexibleStakingSubscription
    /// </summary>
    [Map("FLEXIBLE_STAKING_SUBSCRIPTION")]
    FlexibleStakingSubscription = 29,
    
    /// <summary>
    /// FlexibleStakingRedemption
    /// </summary>
    [Map("FLEXIBLE_STAKING_REDEMPTION")]
    FlexibleStakingRedemption = 30,
    
    /// <summary>
    /// FixedStakingSubscription
    /// </summary>
    [Map("FIXED_STAKING_SUBSCRIPTION")]
    FixedStakingSubscription = 31,
    
    /// <summary>
    /// PremarketTransferOut
    /// </summary>
    [Map("PREMARKET_TRANSFER_OUT")]
    PremarketTransferOut = 32,
    
    /// <summary>
    /// PremarketDeliverySellNewCoin
    /// </summary>
    [Map("PREMARKET_DELIVERY_SELL_NEW_COIN")]
    PremarketDeliverySellNewCoin = 33,
    
    /// <summary>
    /// PremarketDeliveryBuyNewCoin
    /// </summary>
    [Map("PREMARKET_DELIVERY_BUY_NEW_COIN")]
    PremarketDeliveryBuyNewCoin = 34,
    
    /// <summary>
    /// PremarketDeliveryPledgePaySeller
    /// </summary>
    [Map("PREMARKET_DELIVERY_PLEDGE_PAY_SELLER")]
    PremarketDeliveryPledgePaySeller = 35,
    
    /// <summary>
    /// PremarketDeliveryPledgeBack
    /// </summary>
    [Map("PREMARKET_DELIVERY_PLEDGE_BACK")]
    PremarketDeliveryPledgeBack = 36,
    
    /// <summary>
    /// PremarketRollbackPledgeBack
    /// </summary>
    [Map("PREMARKET_ROLLBACK_PLEDGE_BACK")]
    PremarketRollbackPledgeBack = 37,
    
    /// <summary>
    /// PremarketRollbackPledgePenaltyToBuyer
    /// </summary>
    [Map("PREMARKET_ROLLBACK_PLEDGE_PENALTY_TO_BUYER")]
    PremarketRollbackPledgePenaltyToBuyer = 38,
    
    /// <summary>
    /// CustodyNetworkFee
    /// </summary>
    [Map("CUSTODY_NETWORK_FEE")]
    CustodyNetworkFee = 39,
    
    /// <summary>
    /// CustodySettleFee
    /// </summary>
    [Map("CUSTODY_SETTLE_FEE")]
    CustodySettleFee = 40,
    
    /// <summary>
    /// CustodyLock
    /// </summary>
    [Map("CUSTODY_LOCK")]
    CustodyLock = 41,
    
    /// <summary>
    /// CustodyUnlock
    /// </summary>
    [Map("CUSTODY_UNLOCK")]
    CustodyUnlock = 42,
    
    /// <summary>
    /// CustodyUnlockRefund
    /// </summary>
    [Map("CUSTODY_UNLOCK_REFUND")]
    CustodyUnlockRefund = 43,
    
    /// <summary>
    /// LoansBorrowFunds
    /// </summary>
    [Map("LOANS_BORROW_FUNDS")]
    LoansBorrowFunds = 44,
    
    /// <summary>
    /// LoansAssetRedemption
    /// </summary>
    [Map("LOANS_ASSET_REDEMPTION")]
    LoansAssetRedemption = 45
}