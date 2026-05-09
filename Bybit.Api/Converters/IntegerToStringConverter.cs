namespace Bybit.Api.Converters;

internal class IntegerToStringConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(int)
            || objectType == typeof(int?)
            || objectType == typeof(long)
            || objectType == typeof(long?);
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteValue(Convert.ToString(value, CultureInfo.InvariantCulture));
    }
}
