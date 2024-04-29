namespace Bybit.Api.Enums;

/// <summary>
/// Bybit transaction type
/// </summary>
public enum BybitTransactionType
{
    /// <summary>
    /// Transfer in
    /// </summary>
    [Label("TRANSFER_IN")]
    TransferIn,

    /// <summary>
    /// Transfer out
    /// </summary>
    [Label("TRANSFER_OUT")]
    TransferOut,

    /// <summary>
    /// Trade
    /// </summary>
    [Label("TRADE")]
    Trade,

    /// <summary>
    /// Settlement
    /// </summary>
    [Label("SETTLEMENT")]
    Settlement,

    /// <summary>
    /// Delivery
    /// </summary>
    [Label("DELIVERY")]
    Delivery,

    /// <summary>
    /// Liquidation
    /// </summary>
    [Label("LIQUIDATION")]
    Liquidation,

    /// <summary>
    /// Auto deleveraging
    /// </summary>
    [Label("ADL")]
    AutoDeleveraging,

    /// <summary>
    /// Airdrop
    /// </summary>
    [Label("AIRDROP")]
    Airdrop,

    /// <summary>
    /// Bonus
    /// </summary>
    [Label("BONUS")]
    Bonus,

    /// <summary>
    /// Bonus expired
    /// </summary>
    [Label("BONUS_RECOLLECT")]
    BonusExpired,

    /// <summary>
    /// Fee refund
    /// </summary>
    [Label("FEE_REFUND")]
    FeeRefund,

    /// <summary>
    /// Interest
    /// </summary>
    [Label("INTEREST")]
    Interest,

    /// <summary>
    /// Currency buy
    /// </summary>
    [Label("CURRENCY_BUY")]
    CurrencyBuy,

    /// <summary>
    /// Currency sell
    /// </summary>
    [Label("CURRENCY_SELL")]
    CurrencySell,

    /// <summary>
    /// InstitutionalLoanBorrowedAmount
    /// </summary>
    [Label("BORROWED_AMOUNT_INS_LOAN")]
    InstitutionalLoanBorrowedAmount,
    
    /// <summary>
    /// InstitutionalLoanPrincipleRepayment
    /// </summary>
    [Label("PRINCIPLE_REPAYMENT_INS_LOAN")]
    InstitutionalLoanPrincipleRepayment,
    
    /// <summary>
    /// InstitutionalLoanInterestRepayment
    /// </summary>
    [Label("INTEREST_REPAYMENT_INS_LOAN")]
    InstitutionalLoanInterestRepayment,
    
    /// <summary>
    /// InstitutionalLoanAutoSoldCollateral
    /// </summary>
    [Label("AUTO_SOLD_COLLATERAL_INS_LOAN")]
    InstitutionalLoanAutoSoldCollateral,
    
    /// <summary>
    /// InstitutionalLoanAutoBuyLiability
    /// </summary>
    [Label("AUTO_BUY_LIABILITY_INS_LOAN")]
    InstitutionalLoanAutoBuyLiability,
    
    /// <summary>
    /// InstitutionalLoanAutoPrincipleRepayment
    /// </summary>
    [Label("AUTO_PRINCIPLE_REPAYMENT_INS_LOAN")]
    InstitutionalLoanAutoPrincipleRepayment,
    
    /// <summary>
    /// InstitutionalLoanAutoInterestRepayment
    /// </summary>
    [Label("AUTO_INTEREST_REPAYMENT_INS_LOAN")]
    InstitutionalLoanAutoInterestRepayment,
    
    /// <summary>
    /// InstitutionalLoanTransferIn
    /// </summary>
    [Label("TRANSFER_IN_INS_LOAN")]
    InstitutionalLoanTransferIn,
    
    /// <summary>
    /// InstitutionalLoanTransferOut
    /// </summary>
    [Label("TRANSFER_OUT_INS_LOAN")]
    InstitutionalLoanTransferOut,
    
    /// <summary>
    /// SpotRepaymentSell
    /// </summary>
    [Label("SPOT_REPAYMENT_SELL")]
    SpotRepaymentSell,
    
    /// <summary>
    /// SpotRepaymentBuy
    /// </summary>
    [Label("SPOT_REPAYMENT_BUY")]
    SpotRepaymentBuy,
    
    /// <summary>
    /// TokensSubscription
    /// </summary>
    [Label("TOKENS_SUBSCRIPTION")]
    TokensSubscription,
    
    /// <summary>
    /// TokensRedemption
    /// </summary>
    [Label("TOKENS_REDEMPTION")]
    TokensRedemption,
    
    /// <summary>
    /// AutoDeduction
    /// </summary>
    [Label("AUTO_DEDUCTION")]
    AutoDeduction,
    
    /// <summary>
    /// FlexibleStakingSubscription
    /// </summary>
    [Label("FLEXIBLE_STAKING_SUBSCRIPTION")]
    FlexibleStakingSubscription,
    
    /// <summary>
    /// FlexibleStakingRedemption
    /// </summary>
    [Label("FLEXIBLE_STAKING_REDEMPTION")]
    FlexibleStakingRedemption,
    
    /// <summary>
    /// FixedStakingSubscription
    /// </summary>
    [Label("FIXED_STAKING_SUBSCRIPTION")]
    FixedStakingSubscription,
    
    /// <summary>
    /// PremarketTransferOut
    /// </summary>
    [Label("PREMARKET_TRANSFER_OUT")]
    PremarketTransferOut,
    
    /// <summary>
    /// PremarketDeliverySellNewCoin
    /// </summary>
    [Label("PREMARKET_DELIVERY_SELL_NEW_COIN")]
    PremarketDeliverySellNewCoin,
    
    /// <summary>
    /// PremarketDeliveryBuyNewCoin
    /// </summary>
    [Label("PREMARKET_DELIVERY_BUY_NEW_COIN")]
    PremarketDeliveryBuyNewCoin,
    
    /// <summary>
    /// PremarketDeliveryPledgePaySeller
    /// </summary>
    [Label("PREMARKET_DELIVERY_PLEDGE_PAY_SELLER")]
    PremarketDeliveryPledgePaySeller,
    
    /// <summary>
    /// PremarketDeliveryPledgeBack
    /// </summary>
    [Label("PREMARKET_DELIVERY_PLEDGE_BACK")]
    PremarketDeliveryPledgeBack,
    
    /// <summary>
    /// PremarketRollbackPledgeBack
    /// </summary>
    [Label("PREMARKET_ROLLBACK_PLEDGE_BACK")]
    PremarketRollbackPledgeBack,
    
    /// <summary>
    /// PremarketRollbackPledgePenaltyToBuyer
    /// </summary>
    [Label("PREMARKET_ROLLBACK_PLEDGE_PENALTY_TO_BUYER")]
    PremarketRollbackPledgePenaltyToBuyer,
    
    /// <summary>
    /// CustodyNetworkFee
    /// </summary>
    [Label("CUSTODY_NETWORK_FEE")]
    CustodyNetworkFee,
    
    /// <summary>
    /// CustodySettleFee
    /// </summary>
    [Label("CUSTODY_SETTLE_FEE")]
    CustodySettleFee,
    
    /// <summary>
    /// CustodyLock
    /// </summary>
    [Label("CUSTODY_LOCK")]
    CustodyLock,
    
    /// <summary>
    /// CustodyUnlock
    /// </summary>
    [Label("CUSTODY_UNLOCK")]
    CustodyUnlock,
    
    /// <summary>
    /// CustodyUnlockRefund
    /// </summary>
    [Label("CUSTODY_UNLOCK_REFUND")]
    CustodyUnlockRefund,
    
    /// <summary>
    /// LoansBorrowFunds
    /// </summary>
    [Label("LOANS_BORROW_FUNDS")]
    LoansBorrowFunds,
    
    /// <summary>
    /// LoansAssetRedemption
    /// </summary>
    [Label("LOANS_ASSET_REDEMPTION")]
    LoansAssetRedemption
}