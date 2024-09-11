using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1743_Restore_the_Array_From_Adjacent_Pairs;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RestoreArray(testCase.AdjacentPairs), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] AdjacentPairs { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
