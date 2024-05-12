
using JetBrains.Annotations;

namespace LeetCode.Problems._0167_Two_Sum_II___Input_Array_Is_Sorted;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.TwoSum(testCase.Numbers, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Numbers { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
