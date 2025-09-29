namespace Bybit.Api.System;

/// <summary>
/// Bybit System Status
/// </summary>
public class BybitSystemStatus
{
    /// <summary>
    /// Id
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; } = "";

    /// <summary>
    /// Title
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; } = "";

    /// <summary>
    /// State
    /// </summary>
    [JsonProperty("state")]
    public BybitSystemState State { get; set; }

    /// <summary>
    /// Begin Timestamp
    /// </summary>
    [JsonProperty("begin")]
    public long BeginTimestamp { get; set; }

    /// <summary>
    /// Begin Time
    /// </summary>
    public DateTime BeginTime { get => BeginTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// End Timestamp
    /// </summary>
    [JsonProperty("end")]
    public long EndTimestamp { get; set; }

    /// <summary>
    /// End Time
    /// </summary>
    public DateTime EndTime { get => EndTimestamp.ConvertFromMilliseconds(); }

    /// <summary>
    /// Href
    /// </summary>
    [JsonProperty("href")]
    public string Href { get; set; } = "";

    /// <summary>
    /// Service Types
    /// </summary>
    [JsonProperty("serviceTypes")]
    public List<BybitSystemServiceType> ServiceTypes { get; set; } = [];

    /// <summary>
    /// Products
    /// </summary>
    [JsonProperty("product")]
    public List<BybitSystemProduct> Products { get; set; } = [];

    /// <summary>
    /// UIDSuffix
    /// </summary>
    [JsonProperty("uidSuffix")]
    public List<int> UidSuffix { get; set; } = [];

    /// <summary>
    /// Maintain Type
    /// </summary>
    [JsonProperty("maintainType")]
    public BybitSystemMaintainType MaintainType { get; set; }

    /// <summary>
    /// Environment
    /// </summary>
    [JsonProperty("env")]
    public BybitSystemEnvironment Environment { get; set; }
}