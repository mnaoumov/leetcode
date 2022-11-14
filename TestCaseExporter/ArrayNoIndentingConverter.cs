using System.Collections;
using Newtonsoft.Json;

namespace TestCaseExporter;

public class ArrayNoIndentingConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteRawValue(JsonConvert.SerializeObject(value, Formatting.None));
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType.IsAssignableTo(typeof(IEnumerable));
    }
}