namespace Bybit.Api.Broker;

/// <summary>
/// Bybit REST API Broker client.
/// </summary>
public class BybitBrokerRestApiClient
{
    private const string _v5BrokerEarningsInfo = "v5/broker/earnings-info";
    private const string _v5BrokerAccountInfo = "v5/broker/account-info";
    private const string _v5BrokerSubMemberDepositRecord = "v5/broker/asset/query-sub-member-deposit-record";
    private const string _v5BrokerApiLimitSet = "v5/broker/apilimit/set";
    private const string _v5BrokerApiLimitQueryCap = "v5/broker/apilimit/query-cap";
    private const string _v5BrokerApiLimitQueryAll = "v5/broker/apilimit/query-all";
    private const string _v5BrokerAwardInfo = "v5/broker/award/info";
    private const string _v5BrokerAwardDistributeAward = "v5/broker/award/distribute-award";
    private const string _v5BrokerAwardDistributionRecord = "v5/broker/award/distribution-record";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitBrokerRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Get exchange broker earnings.
    /// </summary>
    public Task<BybitRestCallResult<BybitBrokerEarnings>> GetEarningsAsync(
        BybitBrokerBusinessType? businessType = null,
        string? begin = null,
        string? end = null,
        string? uid = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken ct = default)
    {
        return GetEarningsAsync(new BybitBrokerEarningsRequest
        {
            BusinessType = businessType,
            Begin = begin,
            End = end,
            Uid = uid,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get exchange broker earnings.
    /// </summary>
    public async Task<BybitRestCallResult<BybitBrokerEarnings>> GetEarningsAsync(BybitBrokerEarningsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidatePairedDateRange(request.Begin, request.End);
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 1000);

        var parameters = new ParameterCollection();
        if (request.BusinessType.HasValue) parameters.AddEnum("bizType", request.BusinessType.Value);
        parameters.AddOptional("begin", request.Begin);
        parameters.AddOptional("end", request.End);
        parameters.AddOptional("uid", request.Uid);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        return await _.SendBybitRequest<BybitBrokerEarnings>(_.BuildUri(_v5BrokerEarningsInfo), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Get exchange broker account information.
    /// </summary>
    public async Task<BybitRestCallResult<BybitBrokerAccountInfo>> GetAccountInfoAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitBrokerAccountInfo>(_.BuildUri(_v5BrokerAccountInfo), HttpMethod.Get, ct, true).ConfigureAwait(false);

    /// <summary>
    /// Get exchange broker subaccount deposit records.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitBrokerSubAccountDeposit>>> GetSubAccountDepositRecordsAsync(
        string? id = null,
        string? transactionId = null,
        string? subMemberId = null,
        string? coin = null,
        long? startTime = null,
        long? endTime = null,
        int? limit = null,
        string? cursor = null,
        CancellationToken ct = default)
    {
        return GetSubAccountDepositRecordsAsync(new BybitBrokerSubAccountDepositRecordsRequest
        {
            Id = id,
            TransactionId = transactionId,
            SubMemberId = subMemberId,
            Coin = coin,
            StartTime = startTime,
            EndTime = endTime,
            Limit = limit,
            Cursor = cursor,
        }, ct);
    }

    /// <summary>
    /// Get exchange broker subaccount deposit records.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitBrokerSubAccountDeposit>>> GetSubAccountDepositRecordsAsync(BybitBrokerSubAccountDepositRecordsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 50);

        var parameters = new ParameterCollection();
        parameters.AddOptional("id", request.Id);
        parameters.AddOptional("txID", request.TransactionId);
        parameters.AddOptional("subMemberId", request.SubMemberId);
        parameters.AddOptional("coin", request.Coin);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);

        var result = await _.SendBybitRequest<BybitListResponse<BybitBrokerSubAccountDeposit>>(_.BuildUri(_v5BrokerSubMemberDepositRecord), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitBrokerSubAccountDeposit>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Set exchange broker subaccount rate limits.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitBrokerRateLimitSetResult>>> SetRateLimitsAsync(IEnumerable<BybitBrokerSetRateLimitItem> items, CancellationToken ct = default)
        => SetRateLimitsAsync(new BybitBrokerSetRateLimitRequest(items), ct);

    /// <summary>
    /// Set exchange broker subaccount rate limits.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitBrokerRateLimitSetResult>>> SetRateLimitsAsync(BybitBrokerSetRateLimitRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateRateLimitItems(request.List);

        var parameters = new ParameterCollection
        {
            { "list", request.List },
        };

        var result = await _.SendBybitRequest<BybitListResponse<BybitBrokerRateLimitSetResult>>(_.BuildUri(_v5BrokerApiLimitSet), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitBrokerRateLimitSetResult>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get exchange broker entity rate limit cap.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitBrokerRateLimitCap>>> GetRateLimitCapAsync(CancellationToken ct = default)
    {
        var result = await _.SendBybitRequest<BybitListResponse<BybitBrokerRateLimitCap>>(_.BuildUri(_v5BrokerApiLimitQueryCap), HttpMethod.Get, ct, true).ConfigureAwait(false);
        if (!result) return result.As<List<BybitBrokerRateLimitCap>>(default!);
        return result.As(result.Data.Payload);
    }

    /// <summary>
    /// Get all configured exchange broker rate limits.
    /// </summary>
    public Task<BybitRestCallResult<List<BybitBrokerRateLimit>>> GetRateLimitsAsync(int? limit = null, string? cursor = null, string? uids = null, CancellationToken ct = default)
        => GetRateLimitsAsync(new BybitBrokerRateLimitsRequest { Limit = limit, Cursor = cursor, Uids = uids }, ct);

    /// <summary>
    /// Get all configured exchange broker rate limits.
    /// </summary>
    public async Task<BybitRestCallResult<List<BybitBrokerRateLimit>>> GetRateLimitsAsync(BybitBrokerRateLimitsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 1000);

        var parameters = new ParameterCollection();
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("cursor", request.Cursor);
        parameters.AddOptional("uids", request.Uids);

        var result = await _.SendBybitRequest<BybitListResponse<BybitBrokerRateLimit>>(_.BuildUri(_v5BrokerApiLimitQueryAll), HttpMethod.Get, ct, true, queryParameters: parameters).ConfigureAwait(false);
        if (!result) return result.As<List<BybitBrokerRateLimit>>(default!);
        return result.As(result.Data.Payload, result.Data.NextPageCursor);
    }

    /// <summary>
    /// Query exchange broker voucher specification.
    /// </summary>
    public Task<BybitRestCallResult<BybitBrokerVoucherSpec>> GetVoucherSpecAsync(string id, CancellationToken ct = default)
        => GetVoucherSpecAsync(new BybitBrokerVoucherSpecRequest(id), ct);

    /// <summary>
    /// Query exchange broker voucher specification.
    /// </summary>
    public async Task<BybitRestCallResult<BybitBrokerVoucherSpec>> GetVoucherSpecAsync(BybitBrokerVoucherSpecRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        var parameters = new ParameterCollection
        {
            { "id", request.Id },
        };

        return await _.SendBybitRequest<BybitBrokerVoucherSpec>(_.BuildUri(_v5BrokerAwardInfo), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Issue an exchange broker voucher.
    /// </summary>
    public Task<BybitRestCallResult> IssueVoucherAsync(string accountId, string awardId, string specCode, decimal amount, string brokerId, CancellationToken ct = default)
        => IssueVoucherAsync(new BybitBrokerIssueVoucherRequest(accountId, awardId, specCode, amount, brokerId), ct);

    /// <summary>
    /// Issue an exchange broker voucher.
    /// </summary>
    public async Task<BybitRestCallResult> IssueVoucherAsync(BybitBrokerIssueVoucherRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateSpecCode(request.SpecCode);

        var parameters = new ParameterCollection
        {
            { "accountId", request.AccountId },
            { "awardId", request.AwardId },
            { "specCode", request.SpecCode },
            { "brokerId", request.BrokerId },
        };
        parameters.AddString("amount", request.Amount);

        return await _.SendBybitRequest(_.BuildUri(_v5BrokerAwardDistributeAward), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query an issued exchange broker voucher.
    /// </summary>
    public Task<BybitRestCallResult<BybitBrokerIssuedVoucher>> GetIssuedVoucherAsync(string accountId, string awardId, string specCode, bool? withUsedAmount = null, CancellationToken ct = default)
        => GetIssuedVoucherAsync(new BybitBrokerIssuedVoucherRequest(accountId, awardId, specCode) { WithUsedAmount = withUsedAmount }, ct);

    /// <summary>
    /// Query an issued exchange broker voucher.
    /// </summary>
    public async Task<BybitRestCallResult<BybitBrokerIssuedVoucher>> GetIssuedVoucherAsync(BybitBrokerIssuedVoucherRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateSpecCode(request.SpecCode);

        var parameters = new ParameterCollection
        {
            { "accountId", request.AccountId },
            { "awardId", request.AwardId },
            { "specCode", request.SpecCode },
        };
        parameters.AddOptional("withUsedAmount", request.WithUsedAmount);

        return await _.SendBybitRequest<BybitBrokerIssuedVoucher>(_.BuildUri(_v5BrokerAwardDistributionRecord), HttpMethod.Post, ct, true, bodyParameters: parameters).ConfigureAwait(false);
    }

    private static void ValidatePairedDateRange(string? begin, string? end)
    {
        if (string.IsNullOrEmpty(begin) != string.IsNullOrEmpty(end))
        {
            throw new ArgumentException("Begin and end must either both be provided or both be omitted.");
        }
    }

    private static void ValidateRateLimitItems(List<BybitBrokerSetRateLimitItem>? items)
    {
        if (items == null || items.Count == 0)
        {
            throw new ArgumentException("At least one rate limit item is required.", nameof(items));
        }

        foreach (var item in items)
        {
            if (item.Rate <= 0)
            {
                throw new ArgumentException("Rate must be greater than zero.", nameof(items));
            }
        }
    }

    private static void ValidateSpecCode(string specCode)
    {
        if (specCode.Length > 8)
        {
            throw new ArgumentException("Spec code must be up to 8 characters.", nameof(specCode));
        }
    }
}
