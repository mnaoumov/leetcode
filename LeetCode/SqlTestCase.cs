using JetBrains.Annotations;

namespace LeetCode;

[UsedImplicitly]
public class SqlTestCase : TestCaseBase
{
    public Dictionary<string, string[]> Headers { get; [UsedImplicitly] init; } = null!;
    public Dictionary<string, object[][]> Rows { get; [UsedImplicitly] init; } = null!;
    public SqlTestCaseOutput Output { get; [UsedImplicitly] init; } = null!;

    public SqlTestCase()
    {
        TimeoutInMilliseconds = 30000;
    }
}