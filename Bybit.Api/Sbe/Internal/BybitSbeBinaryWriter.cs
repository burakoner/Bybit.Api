namespace Bybit.Api.Sbe;

internal sealed class BybitSbeBinaryWriter
{
    private readonly List<byte> buffer = [];

    public int Length { get => buffer.Count; }

    public byte[] ToArray() => [.. buffer];

    public void WriteHeader(ushort blockLength, ushort templateId, ushort schemaId, ushort version)
    {
        WriteUInt16(blockLength);
        WriteUInt16(templateId);
        WriteUInt16(schemaId);
        WriteUInt16(version);
    }

    public void WriteByte(byte value) => buffer.Add(value);

    public void WriteSByte(sbyte value)
    {
        unchecked
        {
            buffer.Add((byte)value);
        }
    }

    public void WriteUInt16(ushort value)
    {
        buffer.Add((byte)value);
        buffer.Add((byte)(value >> 8));
    }

    public void WriteUInt32(uint value)
    {
        buffer.Add((byte)value);
        buffer.Add((byte)(value >> 8));
        buffer.Add((byte)(value >> 16));
        buffer.Add((byte)(value >> 24));
    }

    public void WriteInt32(int value)
    {
        unchecked
        {
            WriteUInt32((uint)value);
        }
    }

    public void WriteUInt64(ulong value)
    {
        for (var i = 0; i < 8; i++)
            buffer.Add((byte)(value >> (8 * i)));
    }

    public void WriteInt64(long value)
    {
        unchecked
        {
            WriteUInt64((ulong)value);
        }
    }

    public void WriteFixedString(string? value, int length)
    {
        var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);
        if (bytes.Length > length)
            throw new ArgumentException($"Value is too long for a fixed {length}-byte SBE string.");

        buffer.AddRange(bytes);
        for (var i = bytes.Length; i < length; i++)
            buffer.Add(0);
    }

    public void WriteVarString8(string? value)
    {
        var bytes = Encoding.UTF8.GetBytes(value ?? string.Empty);
        if (bytes.Length > byte.MaxValue)
            throw new ArgumentException("Value is too long for varString8.");

        WriteByte((byte)bytes.Length);
        buffer.AddRange(bytes);
    }

    public void WriteDecimal64(BybitSbeDecimal64 value)
    {
        WriteSByte(value.Exponent);
        WriteInt64(value.Mantissa);
    }
}
