using JetBrains.Annotations;

namespace LeetCode._1964_Find_the_Longest_Valid_Obstacle_Course_at_Each_Position;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.LongestObstacleCourseAtEachPosition(testCase.Obstacles), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Obstacles { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
