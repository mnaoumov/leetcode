using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetCode;

public abstract class TestCaseBase
{
    [JsonIgnore]
    public string? TestCaseName { get; set; }

    [JsonIgnore]
    public Exception? JsonParsingException { get; init; }

    public int TimeoutInMilliseconds { get; [UsedImplicitly] init; } = 200;

    public bool ShouldSerializeTimeoutInMilliseconds() => TimeoutInMilliseconds != 200;
}
