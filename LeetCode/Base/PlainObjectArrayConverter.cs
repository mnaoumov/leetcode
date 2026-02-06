using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LeetCode.Base;

internal sealed class PlainObjectArrayConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
    {
        var obj = serializer.Deserialize(reader);
        return ReplaceJArrayWithObjectArray(obj);
    }

    private static object? ReplaceJArrayWithObjectArray(object? obj)
    {
        if (obj is JValue jValue)
        {
            return jValue.Value;
        }

        if (obj is not JArray jArray)
        {
            return obj;
        }

        var array = jArray.Select(ReplaceJArrayWithObjectArray).ToArray();
        return array;
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(object[]) || objectType == typeof(object);
    }
}
