using System.Text.Json.Nodes;
using TemplateGenerator;

namespace LeetCode.Tests.TemplateGenerator;

public class NoIndentArrayJsonTextWriterTests
{
    [Test]
    public void Indent_Null_ReturnsNullString()
    {
        Assert.That(NoIndentArrayJsonTextWriter.Indent(null), Is.EqualTo("null"));
    }

    [Test]
    public void Indent_SimpleObject_IndentsCorrectly()
    {
        var node = JsonNode.Parse("{\"a\": 1, \"b\": 2}");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Does.Contain("\"a\": 1"));
        Assert.That(result, Does.Contain("\"b\": 2"));
    }

    [Test]
    public void Indent_Array_CollapsesToSingleLine()
    {
        var node = JsonNode.Parse("[1, 2, 3]");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Is.EqualTo("[1, 2, 3]"));
    }

    [Test]
    public void Indent_NestedArray_CollapsedToSingleLine()
    {
        var node = JsonNode.Parse("[[1, 2], [3, 4]]");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Is.EqualTo("[[1, 2], [3, 4]]"));
    }

    [Test]
    public void Indent_ObjectWithArray_ArrayCollapsedObjectIndented()
    {
        var node = JsonNode.Parse("{\"values\": [1, 2, 3]}");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Does.Contain("[1, 2, 3]"));
        Assert.That(result, Does.Contain("\"values\":"));
    }

    [Test]
    public void Indent_ArrayWithStrings_PreservesStrings()
    {
        var node = JsonNode.Parse("[\"hello\", \"world\"]");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Is.EqualTo("[\"hello\", \"world\"]"));
    }

    [Test]
    public void Indent_ArrayWithEscapedStrings_HandlesEscapes()
    {
        // System.Text.Json serializes embedded quotes as \u0022
        var node = JsonNode.Parse("[\"a\\\"b\", \"c\"]");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Does.Contain("a\\u0022b"));
    }

    [Test]
    public void Indent_EmptyArray_CollapsesCorrectly()
    {
        var node = JsonNode.Parse("[]");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Is.EqualTo("[]"));
    }

    [Test]
    public void Indent_MixedNestedArrays_AllCollapsed()
    {
        var node = JsonNode.Parse("{\"a\": [1], \"b\": [[2, 3], [4]]}");
        var result = NoIndentArrayJsonTextWriter.Indent(node);
        Assert.That(result, Does.Contain("[1]"));
        Assert.That(result, Does.Contain("[[2, 3], [4]]"));
    }
}
