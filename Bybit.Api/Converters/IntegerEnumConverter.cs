namespace Bybit.Api.Converters;

internal class IntegerEnumConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        var type = Nullable.GetUnderlyingType(objectType) ?? objectType;
        return type.IsEnum;
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        if (reader.TokenType == JsonToken.Null)
            return null;

        var enumType = Nullable.GetUnderlyingType(objectType) ?? objectType;
        if (reader.Value is string value)
            return Enum.Parse(enumType, value);

        return Enum.ToObject(enumType, Convert.ToInt32(reader.Value, CultureInfo.InvariantCulture));
    }

    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        if (value is null)
        {
            writer.WriteNull();
            return;
        }

        writer.WriteValue(Convert.ToInt32(value, CultureInfo.InvariantCulture));
    }
}
