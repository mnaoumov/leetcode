namespace LeetCode.Problems._3603_Minimum_Cost_Path_with_Alternating_Directions_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.M, testCase.N, testCase.WaitCost), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[][] WaitCost { get; [UsedImplicitly] init; } = null!;
        public long Output { get; [UsedImplicitly] init; }
    }
}
