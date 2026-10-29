using System.Text.Json.Serialization;

namespace LeetCode.Bash;

public class BashTestCase : TestCaseBase
{
    public BashTestCase()
    {
        TimeoutInMilliseconds = 30000;
    }

    [JsonOptionalProperty]
    public Dictionary<string, string> Files { get; [UsedImplicitly] init; } = new();

    public string StandardOutput { get; [UsedImplicitly] init; } = "";

    [JsonOptionalProperty]
    public string StandardError { get; [UsedImplicitly] init; } = "";
}
