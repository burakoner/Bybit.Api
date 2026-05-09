namespace Bybit.Api.Position;

/// <summary>
/// Move positions request.
/// </summary>
public record BybitPositionMovePositionsRequest
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitPositionMovePositionsRequest"/> record.
    /// </summary>
    /// <param name="fromUid">Source UID.</param>
    /// <param name="toUid">Destination UID.</param>
    /// <param name="list">Position legs.</param>
    public BybitPositionMovePositionsRequest(string fromUid, string toUid, IEnumerable<BybitPositionMoveRequest> list)
    {
        FromUid = fromUid;
        ToUid = toUid;
        List = list;
    }

    /// <summary>
    /// Source UID.
    /// </summary>
    public string FromUid { get; set; }

    /// <summary>
    /// Destination UID.
    /// </summary>
    public string ToUid { get; set; }

    /// <summary>
    /// Position legs.
    /// </summary>
    public IEnumerable<BybitPositionMoveRequest> List { get; set; }
}
