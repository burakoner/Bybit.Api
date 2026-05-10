namespace Bybit.Api.Sbe;

internal sealed class BybitSbeBinaryReader
{
    private readonly byte[] data;

    public BybitSbeBinaryReader(byte[] data)
    {
        this.data = data ?? throw new ArgumentNullException(nameof(data));
    }

    public int Offset { get; private set; }

    public int Remaining { get => data.Length - Offset; }

    public BybitSbeMessageHeader ReadHeader()
    {
        return new BybitSbeMessageHeader(ReadUInt16(), ReadUInt16(), ReadUInt16(), ReadUInt16());
    }

    public byte ReadByte()
    {
        Require(1);
        return data[Offset++];
    }

    public sbyte ReadSByte()
    {
        unchecked
        {
            return (sbyte)ReadByte();
        }
    }

    public ushort ReadUInt16()
    {
        Require(2);
        var value = (ushort)(data[Offset] | (data[Offset + 1] << 8));
        Offset += 2;
        return value;
    }

    public uint ReadUInt32()
    {
        Require(4);
        var value = (uint)data[Offset]
            | ((uint)data[Offset + 1] << 8)
            | ((uint)data[Offset + 2] << 16)
            | ((uint)data[Offset + 3] << 24);
        Offset += 4;
        return value;
    }

    public int ReadInt32()
    {
        unchecked
        {
            return (int)ReadUInt32();
        }
    }

    public ulong ReadUInt64()
    {
        Require(8);
        ulong value = 0;
        for (var i = 0; i < 8; i++)
            value |= ((ulong)data[Offset + i]) << (8 * i);

        Offset += 8;
        return value;
    }

    public long ReadInt64()
    {
        unchecked
        {
            return (long)ReadUInt64();
        }
    }

    public string ReadFixedString(int length)
    {
        Require(length);
        var start = Offset;
        var end = start;
        var limit = start + length;
        while (end < limit && data[end] != 0)
            end++;

        Offset += length;
        return Encoding.UTF8.GetString(data, start, end - start);
    }

    public string ReadVarString8()
    {
        var length = ReadByte();
        Require(length);
        var value = Encoding.UTF8.GetString(data, Offset, length);
        Offset += length;
        return value;
    }

    public void Skip(int length)
    {
        Require(length);
        Offset += length;
    }

    private void Require(int length)
    {
        if (length < 0 || Offset + length > data.Length)
            throw new ArgumentException("SBE frame does not contain enough bytes for the requested field.");
    }
}
