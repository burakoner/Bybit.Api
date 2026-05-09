namespace Bybit.Api.Rfq;

internal record BybitRfqListResponse<T>
{
    [JsonProperty("list")]
    public List<T> List { get; set; } = [];

    [JsonProperty("cursor")]
    public string Cursor { get; set; } = string.Empty;
}
