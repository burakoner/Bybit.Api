namespace Bybit.Api.Models.Market;

public class BybitSpotInstrument
{
    public string Symbol { get; set; }
    public string BaseCoin { get; set; }
    public string QuoteCoin { get; set; }

    [JsonConverter(typeof(BooleanConverter))]
    public bool? Innovation { get; set; }

    public BybitSpotInstrumentLotSizeFilter LotSizeFilter { get; set; }
    public BybitSpotInstrumentPriceFilter PriceFilter { get; set; }
}
public class BybitSpotInstrumentLotSizeFilter
{
    [JsonProperty("minOrderQty")]
    public decimal MinimumOrderQuantity { get; set; }

    [JsonProperty("maxOrderQty")]
    public decimal MaximumOrderQuantity { get; set; }
    
    [JsonProperty("minOrderAmt")]
    public decimal MinimumOrderAmount { get; set; }

    [JsonProperty("maxOrderAmt")]
    public decimal MaximumOrderAmount { get; set; }

    public int BasePrecision { get; set; }
    public int QuotePrecision { get; set; }
}
public class BybitSpotInstrumentPriceFilter
{
    public decimal TickSize { get; set; }
}


public class BybitLinearInverseInstrument
{
    public string Symbol { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitContractType>))]
    public BybitContractType ContractType { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitInstrumentStatus Status { get; set; }

    public string BaseCoin { get; set; }
    public string QuoteCoin { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? LaunchTime { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? DeliveryTime { get; set; }

    public decimal? DeliveryFeeRate { get; set; }
    public int PriceScale { get; set; }
    [JsonProperty("leverageFilter")]
    public BybitLinearInverseInstrumentLeverageFilter Leverage { get; set; }
    public BybitLinearInverseInstrumentPriceFilter PriceFilter { get; set; }
    public BybitLinearInverseInstrumentLotSizeFilter LotSizeFilter { get; set; }
    [JsonConverter(typeof(BooleanConverter))]
    public bool? UnifiedMarginTrade { get; set; }
    public int? FundingInterval { get; set; }
    public string SettleCoin { get; set; }

}
public class BybitLinearInverseInstrumentLeverageFilter
{
    [JsonProperty("minLeverage")]
    public decimal MinimumLeverage { get; set; }

    [JsonProperty("maxLeverage")]
    public decimal MaximumLeverage { get; set; }
    
    public decimal LeverageStep { get; set; }
}
public class BybitLinearInverseInstrumentPriceFilter
{
    [JsonProperty("minPrice")]
    public decimal MinimumPrice { get; set; }

    [JsonProperty("maxPrice")]
    public decimal MaximumPrice { get; set; }

    public decimal TickSize { get; set; }
}
public class BybitLinearInverseInstrumentLotSizeFilter
{
    [JsonProperty("maxOrderQty")]
    public decimal MaximumOrderQuantity { get; set; }

    [JsonProperty("minOrderQty")]
    public decimal MinimumOrderQuantity { get; set; }

    [JsonProperty("qtyStep")]
    public decimal QuantityStep { get; set; }

    [JsonProperty("postOnlyMaxOrderQty")]
    public decimal PostOnlyMaximumOrderQuantity { get; set; }
}


public class BybitOptionInstrument
{
    public string Symbol { get; set; }

    [JsonConverter(typeof(LabelConverter<BybitOptionType>))]
    public BybitOptionType OptionsType { get; set; }

    [ JsonConverter(typeof(LabelConverter<BybitCategory>))]
    public BybitInstrumentStatus Status { get; set; }

    public string BaseCoin { get; set; }
    public string QuoteCoin { get; set; }
    public string SettleCoin { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? LaunchTime { get; set; }

    [JsonConverter(typeof(DateTimeConverter))]
    public DateTime? DeliveryTime { get; set; }

    public decimal? DeliveryFeeRate { get; set; }
    public BybitOptionsInstrumentPriceFilter PriceFilter { get; set; }
    public BybitOptionsInstrumentLotSizeFilter LotSizeFilter { get; set; }
}
public class BybitOptionsInstrumentPriceFilter
{
    [JsonProperty("minPrice")]
    public decimal MinimumPrice { get; set; }

    [JsonProperty("maxPrice")]
    public decimal MaximumPrice { get; set; }

    [JsonProperty("tickSize")]
    public decimal TickSize { get; set; }
}
public class BybitOptionsInstrumentLotSizeFilter
{
    [JsonProperty("maxOrderQty")]
    public decimal MaximumOrderQuantity { get; set; }

    [JsonProperty("minOrderQty")]
    public decimal MinimumOrderQuantity { get; set; }

    [JsonProperty("qtyStep")]
    public decimal QuantityStep { get; set; }
}
