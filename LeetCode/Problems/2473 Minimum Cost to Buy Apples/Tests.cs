
using JetBrains.Annotations;

namespace LeetCode.Problems._2473_Minimum_Cost_to_Buy_Apples;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinCost(testCase.N, testCase.Roads, testCase.AppleCost, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Roads { get; [UsedImplicitly] init; } = null!;
        public int[] AppleCost { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
