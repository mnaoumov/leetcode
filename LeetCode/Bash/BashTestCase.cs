using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetCode;

public class BashTestCase : TestCaseBase
{
    public BashTestCase()
    {
        TimeoutInMilliseconds = 30000;
    }

    [JsonProperty(Required = Required.Default)]
    public Dictionary<string, string> Files { get; [UsedImplicitly] init; } = new();

    public string StandardOutput { get; [UsedImplicitly] init; } = "";

    [JsonProperty(Required = Required.Default)]
    public string StandardError { get; [UsedImplicitly] init; } = "";
}
