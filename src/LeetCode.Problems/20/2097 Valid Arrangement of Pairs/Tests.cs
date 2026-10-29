namespace LeetCode.Problems._2097_Valid_Arrangement_of_Pairs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ValidArrangement(testCase.Pairs), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Pairs { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
