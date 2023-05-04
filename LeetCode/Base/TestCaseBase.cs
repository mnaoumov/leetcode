using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetCode;

public abstract class TestCaseBase
{
    [JsonIgnore]
    public string? TestCaseName { get; set; }

    [JsonIgnore]
    public Exception? JsonParsingException { get; init; }

    public const int DefaultTimeoutInMilliseconds = 200;

    public int TimeoutInMilliseconds { get; [UsedImplicitly] init; } = DefaultTimeoutInMilliseconds;

    public bool ShouldSerializeTimeoutInMilliseconds() => TimeoutInMilliseconds != DefaultTimeoutInMilliseconds;
}
