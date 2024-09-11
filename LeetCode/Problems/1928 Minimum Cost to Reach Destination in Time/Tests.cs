namespace LeetCode.Problems._1928_Minimum_Cost_to_Reach_Destination_in_Time;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.MaxTime, testCase.Edges, testCase.PassingFees), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int MaxTime { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int[] PassingFees { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
