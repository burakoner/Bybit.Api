namespace Bybit.Api.System;

/// <summary>
/// Bybit Rest API System Client
/// </summary>
public class BybitSystemRestApiClient
{
    // Market Endpoints
    private const string _v5SystemStatus = "v5/system/status";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitSystemRestApiClient(BybitRestApiClient root)
    {
        this._ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get the system status when there is a platform maintenance or service incident.
    /// Please note currently system maintenance that may result in short interruption (lasting less than 10 seconds) or websocket disconnection (users can immediately reconnect) will not be announced.
    /// </summary>
    /// <param name="id">id. Unique identifier</param>
    /// <param name="state">system state</param>
    /// <param name="ct">Cancellation Token</param>
    /// <returns></returns>
    public async Task<BybitRestCallResult<List<BybitSystemStatus>>> GetSystemStatusAsync(string? id=null, BybitSystemState? state=null, CancellationToken ct = default)
    {
        var parameters = new ParameterCollection();
        parameters.AddOptional("id", id);
        parameters.AddOptionalEnum("state", state);

        var result = await _.SendBybitRequest<BybitListResponse<BybitSystemStatus>>(_.BuildUri(_v5SystemStatus), HttpMethod.Get, ct, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitSystemStatus>>([]);
        return result.As(result.Data.Payload);
    }
}
