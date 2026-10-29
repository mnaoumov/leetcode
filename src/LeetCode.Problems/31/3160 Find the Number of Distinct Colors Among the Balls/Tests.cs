namespace LeetCode.Problems._3160_Find_the_Number_of_Distinct_Colors_Among_the_Balls;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.QueryResults(testCase.Limit, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int Limit { get; [UsedImplicitly] init; }
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
