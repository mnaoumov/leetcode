using System.Collections;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestCaseExporter;

public class ArrayNoIndentingConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableTo(typeof(IEnumerable)) && typeToConvert != typeof(string);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return new InnerConverter();
    }

    private sealed class InnerConverter : JsonConverter<object>
    {
        public override object Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            var noIndentOptions = new JsonSerializerOptions(options)
            {
                WriteIndented = false,
                Converters = { }
            };
            // Remove this converter to avoid infinite recursion
            foreach (var converter in options.Converters)
            {
                if (converter is not ArrayNoIndentingConverter)
                {
                    noIndentOptions.Converters.Add(converter);
                }
            }

            var json = JsonSerializer.Serialize(value, value.GetType(), noIndentOptions);
            writer.WriteRawValue(json);
        }
    }
}
