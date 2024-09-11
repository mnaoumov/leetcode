
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0210_Course_Schedule_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindOrder(testCase.NumCourses, testCase.Prerequisites), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int NumCourses { get; [UsedImplicitly] init; }
        public int[][] Prerequisites { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
