using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using LeetCode.Base;

namespace LeetCode.Tests.Base;

public class AllPropertiesRequiredModifierTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { AllPropertiesRequiredModifier.MakePropertiesRequired }
        }
    };

    private class RequiredTestModel
    {
        public string Name { get; init; } = null!;
        public int Value { get; init; }
    }

    private class OptionalTestModel
    {
        public string Name { get; init; } = null!;

        [JsonOptionalProperty]
        public int? OptionalValue { get; init; }
    }

    [Test]
    public void MissingRequiredProperty_ThrowsJsonException()
    {
        Assert.Throws<JsonException>(() =>
            JsonSerializer.Deserialize<RequiredTestModel>("{\"name\": \"test\"}", Options));
    }

    [Test]
    public void AllPropertiesPresent_Succeeds()
    {
        var result = JsonSerializer.Deserialize<RequiredTestModel>(
            "{\"name\": \"test\", \"value\": 42}", Options);
        Assert.That(result!.Name, Is.EqualTo("test"));
        Assert.That(result.Value, Is.EqualTo(42));
    }

    [Test]
    public void OptionalProperty_CanBeOmitted()
    {
        var result = JsonSerializer.Deserialize<OptionalTestModel>(
            "{\"name\": \"test\"}", Options);
        Assert.That(result!.Name, Is.EqualTo("test"));
        Assert.That(result.OptionalValue, Is.Null);
    }
}
