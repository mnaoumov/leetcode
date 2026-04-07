using System.Text.Json;
using System.Text.Json.Serialization;

namespace LeetCode.Base;

internal sealed class PlainObjectArrayConverter : JsonConverter<object>
{
    public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return ReadValue(ref reader);
    }

    public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value, value.GetType(), options);
    }

    private static object? ReadValue(ref Utf8JsonReader reader)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.Null:
                return null;
            case JsonTokenType.True:
                return true;
            case JsonTokenType.False:
                return false;
            case JsonTokenType.String:
                return reader.GetString();
            case JsonTokenType.Number:
                if (reader.TryGetInt32(out var intValue))
                {
                    return intValue;
                }

                if (reader.TryGetInt64(out var longValue))
                {
                    return longValue;
                }

                return reader.GetDouble();
            case JsonTokenType.StartArray:
                return ReadArray(ref reader);
            case JsonTokenType.StartObject:
                return JsonElement.ParseValue(ref reader);
            default:
                throw new JsonException($"Unexpected token type: {reader.TokenType}");
        }
    }

    private static object?[] ReadArray(ref Utf8JsonReader reader)
    {
        var list = new List<object?>();

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndArray)
            {
                return list.ToArray();
            }

            list.Add(ReadValue(ref reader));
        }

        throw new JsonException("Unexpected end of JSON while reading array");
    }
}
