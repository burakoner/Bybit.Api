namespace Bybit.Api.Sbe;

/// <summary>
/// SBE message header.
/// </summary>
public record BybitSbeMessageHeader
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BybitSbeMessageHeader"/> record.
    /// </summary>
    public BybitSbeMessageHeader(ushort blockLength, ushort templateId, ushort schemaId, ushort version)
    {
        BlockLength = blockLength;
        TemplateId = templateId;
        SchemaId = schemaId;
        Version = version;
    }

    /// <summary>
    /// Fixed body length.
    /// </summary>
    public ushort BlockLength { get; }

    /// <summary>
    /// Message type identifier.
    /// </summary>
    public ushort TemplateId { get; }

    /// <summary>
    /// Schema identifier.
    /// </summary>
    public ushort SchemaId { get; }

    /// <summary>
    /// Schema version.
    /// </summary>
    public ushort Version { get; }
}
