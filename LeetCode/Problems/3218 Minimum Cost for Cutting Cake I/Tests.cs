namespace LeetCode.Problems._3218_Minimum_Cost_for_Cutting_Cake_I;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumCost(testCase.M, testCase.N, testCase.HorizontalCut, testCase.VerticalCut), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[] HorizontalCut { get; [UsedImplicitly] init; } = null!;
        public int[] VerticalCut { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
