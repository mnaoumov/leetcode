using System.Text.Json.Serialization;

namespace LeetCode.Base;

public abstract class TestCaseBase
{
    [JsonPropertyName("$schema")]
    [JsonPropertyOrder(int.MinValue)]
    [JsonOptionalProperty]
    public string Schema { get; [UsedImplicitly] init; } = "../../Base/testcase.schema.json";

    [JsonIgnore]
    public string? TestCaseName { get; set; }

    [JsonIgnore]
    public Exception? JsonParsingException { get; init; }

    private const int DefaultTimeoutInMilliseconds = 200;

    public int TimeoutInMilliseconds { get; [UsedImplicitly] init; } = DefaultTimeoutInMilliseconds;
}
