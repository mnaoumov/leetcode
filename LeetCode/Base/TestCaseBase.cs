using Newtonsoft.Json;

namespace LeetCode.Base;

public abstract class TestCaseBase
{
    [JsonIgnore]
    public string? TestCaseName { get; set; }

    [JsonIgnore]
    public Exception? JsonParsingException { get; init; }

    private const int DefaultTimeoutInMilliseconds = 200;

    public int TimeoutInMilliseconds { get; [UsedImplicitly] init; } = DefaultTimeoutInMilliseconds;

    public bool ShouldSerializeTimeoutInMilliseconds() => TimeoutInMilliseconds != DefaultTimeoutInMilliseconds;
}
