using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2373_Largest_Local_Values_in_a_Matrix;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LargestLocal(testCase.Grid), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
