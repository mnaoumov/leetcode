using JetBrains.Annotations;
using Newtonsoft.Json;

namespace LeetCode;

[UsedImplicitly]
public class SqlTestCase : TestCaseBase
{
    public SqlTestCase()
    {
        TimeoutInMilliseconds = 30000;
    }

    public Dictionary<string, string[]> Headers { get; [UsedImplicitly] init; } = null!;
    public Dictionary<string, object?[][]> Rows { get; [UsedImplicitly] init; } = null!;
    public SqlTestCaseOutput Output { get; [UsedImplicitly] init; } = null!;

    [JsonProperty(Required = Required.Default)]
    public object? Argument { get; [UsedImplicitly] init; }
}
