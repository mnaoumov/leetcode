namespace LeetCode.Problems._3532_Path_Existence_Queries_in_a_Graph_I;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.PathExistenceQueries(testCase.N, testCase.Nums, testCase.MaxDiff, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int MaxDiff { get; [UsedImplicitly] init; }
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public bool[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
