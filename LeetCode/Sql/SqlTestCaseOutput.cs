using JetBrains.Annotations;

namespace LeetCode;

public class SqlTestCaseOutput
{
    public string[] Headers { get; [UsedImplicitly] init; } = null!;
    public object?[][] Values { get; [UsedImplicitly] init; } = null!;
}
