using System.Text.Json.Serialization;

namespace LeetCode.ClassDesign;

public class ClassDesignTestCase : TestCaseBase
{
    /// <summary>
    /// Tells the shared test case schema to check this file as a class design test case.
    /// </summary>
    [JsonPropertyOrder(int.MinValue + 1)]
    [JsonOptionalProperty]
    public string Kind { get; [UsedImplicitly] init; } = "classDesign";

    public string[] Commands { get; [UsedImplicitly] init; } = null!;
    public object[][] Parameters { get; [UsedImplicitly] init; } = null!;
    public object[] Output { get; [UsedImplicitly] init; } = null!;
}
