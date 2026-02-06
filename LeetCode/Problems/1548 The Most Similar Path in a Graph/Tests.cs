namespace LeetCode.Problems._1548_The_Most_Similar_Path_in_a_Graph;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MostSimilar(testCase.N, testCase.Roads, testCase.Names, testCase.TargetPath), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Roads { get; [UsedImplicitly] init; } = null!;
        public string[] Names { get; [UsedImplicitly] init; } = null!;
        public string[] TargetPath { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
