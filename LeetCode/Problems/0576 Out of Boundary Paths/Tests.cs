namespace LeetCode.Problems._0576_Out_of_Boundary_Paths;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindPaths(testCase.M, testCase.N, testCase.MaxMove, testCase.StartRow, testCase.StartColumn), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int MaxMove { get; [UsedImplicitly] init; }
        public int StartRow { get; [UsedImplicitly] init; }
        public int StartColumn { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
