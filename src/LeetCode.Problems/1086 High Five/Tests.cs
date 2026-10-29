namespace LeetCode.Problems._1086_High_Five;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.HighFive(testCase.Items), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Items { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
