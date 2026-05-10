namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit Card asset record.
/// </summary>
public record BybitCardAssetRecord
{
    /// <summary>
    /// Last 4 digits of card number.
    /// </summary>
    public string Pan4 { get; set; } = string.Empty;

    /// <summary>
    /// First 6 digits of card number.
    /// </summary>
    public string Pan6 { get; set; } = string.Empty;

    /// <summary>
    /// Trade status.
    /// </summary>
    public BybitCardTradeStatus TradeStatus { get; set; }

    /// <summary>
    /// Transaction type.
    /// </summary>
    public BybitCardTransactionSide Side { get; set; }

    /// <summary>
    /// Total amount.
    /// </summary>
    public decimal? BasicAmount { get; set; }

    /// <summary>
    /// Total amount currency code.
    /// </summary>
    public string BasicCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Amount before tax.
    /// </summary>
    public decimal? TransactionAmount { get; set; }

    /// <summary>
    /// Amount before tax currency code.
    /// </summary>
    public string TransactionCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Transaction creation timestamp in milliseconds.
    /// </summary>
    public long TxnCreate { get; set; }

    /// <summary>
    /// Transaction creation time.
    /// </summary>
    public DateTime TxnCreateTime { get => TxnCreate.ConvertFromMilliseconds(); }

    /// <summary>
    /// Merchant country.
    /// </summary>
    public string MerchCountry { get; set; } = string.Empty;

    /// <summary>
    /// Merchant city.
    /// </summary>
    public string MerchCity { get; set; } = string.Empty;

    /// <summary>
    /// Merchant name.
    /// </summary>
    public string MerchName { get; set; } = string.Empty;

    /// <summary>
    /// Transaction ID.
    /// </summary>
    public string TxnId { get; set; } = string.Empty;

    /// <summary>
    /// Declined reason.
    /// </summary>
    public string DeclinedReason { get; set; } = string.Empty;

    /// <summary>
    /// Total fees.
    /// </summary>
    public decimal? TotalFees { get; set; }

    /// <summary>
    /// User ID.
    /// </summary>
    public long Uid { get; set; }

    /// <summary>
    /// Fiat transaction amount.
    /// </summary>
    public decimal? TransactionCurrencyAmount { get; set; }

    /// <summary>
    /// Fee.
    /// </summary>
    public decimal? FxPad { get; set; }

    /// <summary>
    /// Interchange fee.
    /// </summary>
    public decimal? InterchangeFee { get; set; }

    /// <summary>
    /// Bill amount.
    /// </summary>
    public decimal? BillAmount { get; set; }

    /// <summary>
    /// Transaction currency amount.
    /// </summary>
    public decimal? PaidAmount { get; set; }

    /// <summary>
    /// Paid currency code.
    /// </summary>
    public string PaidCurrency { get; set; } = string.Empty;

    /// <summary>
    /// Trial bonus.
    /// </summary>
    public decimal? BonusAmount { get; set; }

    /// <summary>
    /// Foreign transaction fee.
    /// </summary>
    public decimal? ForeignTransactionFee { get; set; }

    /// <summary>
    /// Total tax.
    /// </summary>
    public decimal? TotalTax { get; set; }

    /// <summary>
    /// Fiat paid amount.
    /// </summary>
    public decimal? PaidFiat { get; set; }

    /// <summary>
    /// Withdrawal fee.
    /// </summary>
    public decimal? WithdrawalFee { get; set; }

    /// <summary>
    /// Transaction status.
    /// </summary>
    public BybitCardTransactionStatus Status { get; set; }

    /// <summary>
    /// Order number.
    /// </summary>
    public string OrderNo { get; set; } = string.Empty;

    /// <summary>
    /// Merchant category code.
    /// </summary>
    public string MccCode { get; set; } = string.Empty;

    /// <summary>
    /// Merchant category description.
    /// </summary>
    public string MerchCategoryDesc { get; set; } = string.Empty;
}
