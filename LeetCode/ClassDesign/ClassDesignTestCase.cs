namespace LeetCode.ClassDesign;

public class ClassDesignTestCase : TestCaseBase
{
    public string[] Commands { get; [UsedImplicitly] init; } = null!;
    public object[][] Parameters { get; [UsedImplicitly] init; } = null!;
    public object[] Output { get; [UsedImplicitly] init; } = null!;
}
