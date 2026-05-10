namespace Bybit.Api.Broker;

/// <summary>
/// Exchange broker voucher spec request.
/// </summary>
public record BybitBrokerVoucherSpecRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitBrokerVoucherSpecRequest"/> record.
    /// </summary>
    /// <param name="id">Voucher ID.</param>
    public BybitBrokerVoucherSpecRequest(string id)
    {
        Id = id;
    }

    /// <summary>
    /// Voucher ID.
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }
}
