using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3266_Final_Array_State_After_K_Multiplication_Operations_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.GetFinalState(testCase.Nums, testCase.K, testCase.Multiplier), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Multiplier { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
