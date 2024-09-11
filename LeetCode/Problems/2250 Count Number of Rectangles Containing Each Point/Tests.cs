
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2250_Count_Number_of_Rectangles_Containing_Each_Point;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CountRectangles(testCase.Rectangles, testCase.Points), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Rectangles { get; [UsedImplicitly] init; } = null!;
        public int[][] Points { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
