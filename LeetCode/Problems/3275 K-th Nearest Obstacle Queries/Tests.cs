using JetBrains.Annotations;

namespace LeetCode.Problems._3275_K_th_Nearest_Obstacle_Queries;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ResultsArray(testCase.Queries, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
