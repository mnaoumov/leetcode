
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0480_Sliding_Window_Median;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MedianSlidingWindow(testCase.Nums, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public double[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
