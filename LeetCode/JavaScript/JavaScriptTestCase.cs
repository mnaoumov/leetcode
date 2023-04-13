using JetBrains.Annotations;

namespace LeetCode;

public class JavaScriptTestCase : TestCaseBase
{
    public string Input { get; [UsedImplicitly] init; } = null!;
    public object Output { get; [UsedImplicitly] init; } = null!;
}