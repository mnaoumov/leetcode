namespace LeetCode.Problems._0071_Simplify_Path;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SimplifyPath(testCase.Path), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Path { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
