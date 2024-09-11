using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1057_Campus_Bikes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.AssignBikes(testCase.Workers, testCase.Bikes), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Workers { get; [UsedImplicitly] init; } = null!;
        public int[][] Bikes { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
