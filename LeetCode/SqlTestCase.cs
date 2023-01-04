using JetBrains.Annotations;

namespace LeetCode;

[UsedImplicitly]
public class SqlTestCase : TestCaseBase
{
    public SqlTestCase()
    {
        TimeoutInMilliseconds = 30000;
    }

    public Dictionary<string, string[]> Headers { get; [UsedImplicitly] init; } = null!;
    public Dictionary<string, object[][]> Rows { get; [UsedImplicitly] init; } = null!;
    public SqlTestCaseOutput Output { get; [UsedImplicitly] init; } = null!;
    public bool IgnoreRowOrder { get; [UsedImplicitly] init; }
}