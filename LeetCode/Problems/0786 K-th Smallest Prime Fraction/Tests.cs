using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0786_K_th_Smallest_Prime_Fraction;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.KthSmallestPrimeFraction(testCase.Arr, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arr { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
