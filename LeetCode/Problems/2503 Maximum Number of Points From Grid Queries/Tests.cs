
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2503_Maximum_Number_of_Points_From_Grid_Queries;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaxPoints(testCase.Grid, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int[] Queries { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
