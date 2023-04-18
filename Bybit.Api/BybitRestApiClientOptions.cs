namespace Bybit.Api;

public class BybitRestApiClientOptions : RestApiClientOptions
{
    // Receive Window
    public TimeSpan ReceiveWindow { get; set; }

    // Auto Timestamp
    public bool AutoTimestamp { get; set; }
    public TimeSpan TimestampRecalculationInterval { get; set; }

    // Demo
    public bool DemoTradingService { get; set; } = false;
    public bool SignPublicRequests { get; set; } = false;

    public BybitRestApiClientOptions() : this(null)
    {
        BaseAddress = BybitApiAddresses.MainNet.RestApiAddress;
    }

    public BybitRestApiClientOptions(ApiCredentials credentials)
    {
        // API Credentials
        ApiCredentials = credentials;

        // Api Addresses
        BaseAddress = BybitApiAddresses.MainNet.RestApiAddress;

        // Receive Window
        ReceiveWindow = TimeSpan.FromSeconds(30);

        // Auto Timestamp
        AutoTimestamp = true;
        TimestampRecalculationInterval = TimeSpan.FromHours(1);

        // Http Options
        HttpOptions = new HttpOptions
        {
            UserAgent = RestApiConstants.USER_AGENT,
            AcceptMimeType = RestApiConstants.JSON_CONTENT_HEADER,
            RequestTimeout = TimeSpan.FromSeconds(30),
            EncodeQueryString = true,
            BodyFormat = RestBodyFormat.Json,
        };

        // Broker Id
        BrokerId = "Ey000284";

        // Request Body
        RequestBodyParameterKey = "BODY";
    }
}