namespace LeetCode.Problems._1462_Course_Schedule_IV;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CheckIfPrerequisite(testCase.NumCourses, testCase.Prerequisites, testCase.Queries), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int NumCourses { get; [UsedImplicitly] init; }
        public int[][] Prerequisites { get; [UsedImplicitly] init; } = null!;
        public int[][] Queries { get; [UsedImplicitly] init; } = null!;
        public IList<bool> Output { get; [UsedImplicitly] init; } = null!;
    }
}
