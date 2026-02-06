namespace LeetCode.Problems._0986_Interval_List_Intersections;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.IntervalIntersection(testCase.FirstList, testCase.SecondList), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] FirstList { get; [UsedImplicitly] init; } = null!;
        public int[][] SecondList { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
