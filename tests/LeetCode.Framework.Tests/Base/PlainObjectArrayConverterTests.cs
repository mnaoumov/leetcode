using System.Text.Json;
using LeetCode.Base;

namespace LeetCode.Tests.Base;

public class PlainObjectArrayConverterTests
{
    private static readonly JsonSerializerOptions Options = new()
    {
        Converters = { new PlainObjectArrayConverter() }
    };

    [Test]
    public void Deserialize_Null_ReturnsNull()
    {
        var result = JsonSerializer.Deserialize<object>("null", Options);
        Assert.That(result, Is.Null);
    }

    [Test]
    public void Deserialize_True_ReturnsTrue()
    {
        var result = JsonSerializer.Deserialize<object>("true", Options);
        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void Deserialize_False_ReturnsFalse()
    {
        var result = JsonSerializer.Deserialize<object>("false", Options);
        Assert.That(result, Is.EqualTo(false));
    }

    [Test]
    public void Deserialize_String_ReturnsString()
    {
        var result = JsonSerializer.Deserialize<object>("\"hello\"", Options);
        Assert.That(result, Is.EqualTo("hello"));
    }

    [Test]
    public void Deserialize_Int_ReturnsInt()
    {
        var result = JsonSerializer.Deserialize<object>("42", Options);
        Assert.That(result, Is.TypeOf<int>());
        Assert.That(result, Is.EqualTo(42));
    }

    [Test]
    public void Deserialize_Long_ReturnsLong()
    {
        var result = JsonSerializer.Deserialize<object>("3000000000", Options);
        Assert.That(result, Is.TypeOf<long>());
        Assert.That(result, Is.EqualTo(3_000_000_000L));
    }

    [Test]
    public void Deserialize_Double_ReturnsDouble()
    {
        var result = JsonSerializer.Deserialize<object>("3.14", Options);
        Assert.That(result, Is.TypeOf<double>());
        Assert.That(result, Is.EqualTo(3.14).Within(1e-10));
    }

    [Test]
    public void Deserialize_Array_ReturnsObjectArray()
    {
        var result = JsonSerializer.Deserialize<object>("[1, \"two\", true, null]", Options);
        Assert.That(result, Is.TypeOf<object?[]>());
        var arr = (object?[])result!;
        Assert.That(arr[0], Is.EqualTo(1));
        Assert.That(arr[1], Is.EqualTo("two"));
        Assert.That(arr[2], Is.EqualTo(true));
        Assert.That(arr[3], Is.Null);
    }

    [Test]
    public void Deserialize_NestedArray_ReturnsNestedObjectArrays()
    {
        var result = JsonSerializer.Deserialize<object>("[[1, 2], [3]]", Options);
        var outer = (object?[])result!;
        Assert.That(outer.Length, Is.EqualTo(2));
        Assert.That(((object?[])outer[0]!)[0], Is.EqualTo(1));
        Assert.That(((object?[])outer[0]!)[1], Is.EqualTo(2));
        Assert.That(((object?[])outer[1]!)[0], Is.EqualTo(3));
    }

    [Test]
    public void Deserialize_Object_ReturnsJsonElement()
    {
        var result = JsonSerializer.Deserialize<object>("{\"key\": \"value\"}", Options);
        Assert.That(result, Is.TypeOf<JsonElement>());
        var element = (JsonElement)result!;
        Assert.That(element.GetProperty("key").GetString(), Is.EqualTo("value"));
    }

    [Test]
    public void Serialize_Roundtrips()
    {
        var value = new object[] { 1, "hello", true };
        var json = JsonSerializer.Serialize<object>(value, Options);
        Assert.That(json, Is.EqualTo("[1,\"hello\",true]"));
    }
}
