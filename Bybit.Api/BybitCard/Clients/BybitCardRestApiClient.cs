namespace Bybit.Api.BybitCard;

/// <summary>
/// Bybit REST API Bybit Card client.
/// </summary>
public class BybitCardRestApiClient
{
    private const string _v5CardTransactionQueryAssetRecords = "v5/card/transaction/query-asset-records";
    private const string _v5CardRewardPointsBalance = "v5/card/reward/points/balance";
    private const string _v5CardRewardPointsRecords = "v5/card/reward/points/records";
    private const string _v5CardRewardPointsTier = "v5/card/reward/points/tier";
    private const string _v5CardRewardMallItemList = "v5/card/reward/mall/item/list";
    private const string _v5CardRewardPointCashbackDetail = "v5/card/reward/point/cashback/detail";

    #region Internal
    internal BybitBaseRestApiClient _ { get; }
    internal BybitCardRestApiClient(BybitRestApiClient root)
    {
        _ = root.BaseClient;
    }
    #endregion

    /// <summary>
    /// Query card transaction history.
    /// </summary>
    public Task<BybitRestCallResult<BybitCardPage<BybitCardAssetRecord>>> GetAssetRecordsAsync(
        BybitCardAssetRecordStatusCode? statusCode = null,
        int? limit = null,
        int? page = null,
        string? pan4 = null,
        long? createBeginTime = null,
        long? createEndTime = null,
        string? merchantName = null,
        BybitCardAssetRecordQueryType? type = null,
        string? transactionId = null,
        string? cardToken = null,
        string? orderNo = null,
        CancellationToken ct = default)
    {
        return GetAssetRecordsAsync(new BybitCardAssetRecordsRequest
        {
            StatusCode = statusCode,
            Limit = limit,
            Page = page,
            Pan4 = pan4,
            CreateBeginTime = createBeginTime,
            CreateEndTime = createEndTime,
            MerchantName = merchantName,
            Type = type,
            TransactionId = transactionId,
            CardToken = cardToken,
            OrderNo = orderNo,
        }, ct);
    }

    /// <summary>
    /// Query card transaction history.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCardPage<BybitCardAssetRecord>>> GetAssetRecordsAsync(BybitCardAssetRecordsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        request.Limit?.ValidateIntBetween(nameof(request.Limit), 1, 500);
        ValidateMinimum(request.Page, nameof(request.Page), 1);

        var parameters = new ParameterCollection();
        AddOptionalEnum(parameters, "statusCode", request.StatusCode);
        parameters.AddOptional("limit", request.Limit);
        parameters.AddOptional("page", request.Page);
        parameters.AddOptional("pan4", request.Pan4);
        parameters.AddOptional("createBeginTime", request.CreateBeginTime);
        parameters.AddOptional("createEndTime", request.CreateEndTime);
        parameters.AddOptional("merchName", request.MerchantName);
        AddOptionalEnum(parameters, "type", request.Type);
        parameters.AddOptional("txnId", request.TransactionId);
        parameters.AddOptional("cardToken", request.CardToken);
        parameters.AddOptional("orderNo", request.OrderNo);

        return await _.SendBybitRequest<BybitCardPage<BybitCardAssetRecord>>(_.BuildUri(_v5CardTransactionQueryAssetRecords), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query card reward point balance.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCardPointBalance>> GetPointBalanceAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitCardPointBalance>(_.BuildUri(_v5CardRewardPointsBalance), HttpMethod.Post, ct, true).ConfigureAwait(false);

    /// <summary>
    /// Query card reward point transaction records.
    /// </summary>
    public Task<BybitRestCallResult<BybitCardPage<BybitCardPointRecord>>> GetPointRecordsAsync(
        string? type = null,
        int? pageSize = null,
        int? pageNo = null,
        long? startTime = null,
        long? endTime = null,
        string? outOrderId = null,
        string? businessId = null,
        string? businessTransactionId = null,
        BybitCardPointSide? side = null,
        CancellationToken ct = default)
    {
        return GetPointRecordsAsync(new BybitCardPointRecordsRequest
        {
            Type = type,
            PageSize = pageSize,
            PageNo = pageNo,
            StartTime = startTime,
            EndTime = endTime,
            OutOrderId = outOrderId,
            BusinessId = businessId,
            BusinessTransactionId = businessTransactionId,
            Side = side,
        }, ct);
    }

    /// <summary>
    /// Query card reward point transaction records.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCardPage<BybitCardPointRecord>>> GetPointRecordsAsync(BybitCardPointRecordsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateMinimum(request.PageSize, nameof(request.PageSize), 1);
        ValidateMinimum(request.PageNo, nameof(request.PageNo), 1);

        var parameters = new ParameterCollection();
        parameters.AddOptional("type", request.Type);
        parameters.AddOptional("pageSize", request.PageSize);
        parameters.AddOptional("pageNo", request.PageNo);
        parameters.AddOptional("startTime", request.StartTime);
        parameters.AddOptional("endTime", request.EndTime);
        parameters.AddOptional("outOrderId", request.OutOrderId);
        parameters.AddOptional("bizId", request.BusinessId);
        parameters.AddOptional("bizTxnId", request.BusinessTransactionId);
        AddOptionalEnum(parameters, "side", request.Side);

        return await _.SendBybitRequest<BybitCardPage<BybitCardPointRecord>>(_.BuildUri(_v5CardRewardPointsRecords), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query card reward tier information.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCardTierInfo>> GetTierInfoAsync(CancellationToken ct = default)
        => await _.SendBybitRequest<BybitCardTierInfo>(_.BuildUri(_v5CardRewardPointsTier), HttpMethod.Post, ct, true).ConfigureAwait(false);

    /// <summary>
    /// Query the list of items available in the card reward mall.
    /// </summary>
    public Task<BybitRestCallResult<BybitCardPage<BybitCardMallItem>>> GetMallItemsAsync(
        int? pageNo = null,
        int? pageSize = null,
        BybitCardMallItemType? itemType = null,
        BybitCardMallItemBizType? itemBusinessType = null,
        BybitCardMallOrderBy? orderBy = null,
        bool? ascending = null,
        BybitCardMallSource? source = null,
        CancellationToken ct = default)
    {
        return GetMallItemsAsync(new BybitCardMallItemsRequest
        {
            PageNo = pageNo,
            PageSize = pageSize,
            ItemType = itemType,
            ItemBusinessType = itemBusinessType,
            OrderBy = orderBy,
            Ascending = ascending,
            Source = source,
        }, ct);
    }

    /// <summary>
    /// Query the list of items available in the card reward mall.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCardPage<BybitCardMallItem>>> GetMallItemsAsync(BybitCardMallItemsRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        ValidateMinimum(request.PageNo, nameof(request.PageNo), 1);
        ValidateMinimum(request.PageSize, nameof(request.PageSize), 1);

        var parameters = new ParameterCollection();
        parameters.AddOptional("pageNo", request.PageNo);
        parameters.AddOptional("pageSize", request.PageSize);
        AddOptionalEnum(parameters, "itemType", request.ItemType);
        AddOptionalEnum(parameters, "itemBizType", request.ItemBusinessType);
        AddOptionalEnum(parameters, "orderBy", request.OrderBy);
        parameters.AddOptional("asc", request.Ascending);
        AddOptionalEnum(parameters, "source", request.Source);

        return await _.SendBybitRequest<BybitCardPage<BybitCardMallItem>>(_.BuildUri(_v5CardRewardMallItemList), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    /// <summary>
    /// Query cashback detail for a specific card reward order.
    /// </summary>
    public Task<BybitRestCallResult<BybitCardCashbackDetail>> GetCashbackDetailAsync(string businessTransactionId, CancellationToken ct = default)
        => GetCashbackDetailAsync(new BybitCardCashbackDetailRequest(businessTransactionId), ct);

    /// <summary>
    /// Query cashback detail for a specific card reward order.
    /// </summary>
    public async Task<BybitRestCallResult<BybitCardCashbackDetail>> GetCashbackDetailAsync(BybitCardCashbackDetailRequest request, CancellationToken ct = default)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));
        if (string.IsNullOrWhiteSpace(request.BusinessTransactionId)) throw new ArgumentException("Business transaction ID is required.", nameof(request));

        var parameters = new ParameterCollection
        {
            { "bizTxnId", request.BusinessTransactionId },
        };

        return await _.SendBybitRequest<BybitCardCashbackDetail>(_.BuildUri(_v5CardRewardPointCashbackDetail), HttpMethod.Post, ct, true, queryParameters: parameters).ConfigureAwait(false);
    }

    private static void AddOptionalEnum<T>(ParameterCollection parameters, string name, T? value) where T : struct, Enum
    {
        if (value.HasValue)
        {
            parameters.AddEnum(name, value.Value);
        }
    }

    private static void ValidateMinimum(int? value, string name, int minimum)
    {
        if (value.HasValue && value.Value < minimum)
        {
            throw new ArgumentException($"{name} must be greater than or equal to {minimum}.", name);
        }
    }
}
