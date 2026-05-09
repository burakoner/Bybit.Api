namespace Bybit.Api.Rfq;

/// <summary>
/// RFQ configuration.
/// </summary>
public record BybitRfqConfig
{
    /// <summary>
    /// Own desk code.
    /// </summary>
    public string DeskCode { get; set; } = string.Empty;

    /// <summary>
    /// Maximum number of legs.
    /// </summary>
    public int MaxLegs { get; set; }

    /// <summary>
    /// Maximum number of selected LPs.
    /// </summary>
    [JsonProperty("maxLP")]
    public int MaxLiquidityProviders { get; set; }

    /// <summary>
    /// Maximum number of active RFQs.
    /// </summary>
    public int MaxActiveRfq { get; set; }

    /// <summary>
    /// RFQ expiration time in minutes.
    /// </summary>
    public int RfqExpireTime { get; set; }

    /// <summary>
    /// Spot minimum limit quantity.
    /// </summary>
    public decimal? MinLimitQtySpotOrder { get; set; }

    /// <summary>
    /// Contract minimum limit quantity.
    /// </summary>
    public decimal? MinLimitQtyContractOrder { get; set; }

    /// <summary>
    /// Option minimum limit quantity.
    /// </summary>
    public decimal? MinLimitQtyOptionOrder { get; set; }

    /// <summary>
    /// Strategy types.
    /// </summary>
    public List<BybitRfqStrategyType> StrategyTypes { get; set; } = [];

    /// <summary>
    /// Available counterparties.
    /// </summary>
    public List<BybitRfqCounterparty> Counterparties { get; set; } = [];
}

/// <summary>
/// RFQ strategy type.
/// </summary>
public record BybitRfqStrategyType
{
    /// <summary>
    /// Strategy name.
    /// </summary>
    public string StrategyName { get; set; } = string.Empty;
}

/// <summary>
/// RFQ counterparty.
/// </summary>
public record BybitRfqCounterparty
{
    /// <summary>
    /// Trader name.
    /// </summary>
    public string TraderName { get; set; } = string.Empty;

    /// <summary>
    /// Counterparty desk code.
    /// </summary>
    public string DeskCode { get; set; } = string.Empty;

    /// <summary>
    /// Quoter type. LP means automated market maker; null means normal quoter.
    /// </summary>
    public string? Type { get; set; }
}
