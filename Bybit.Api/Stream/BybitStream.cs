namespace Bybit.Api.Stream;

public class BybitStream
{
    public BybitStreamType StreamType { get; set; }
}

public class BybitCategoryStream : BybitStream
{
    public BybitCategory Category { get; set; }
}

