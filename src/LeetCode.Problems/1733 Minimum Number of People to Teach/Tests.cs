namespace LeetCode.Problems._1733_Minimum_Number_of_People_to_Teach;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumTeachings(testCase.N, testCase.Languages, testCase.Friendships), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Languages { get; [UsedImplicitly] init; } = null!;
        public int[][] Friendships { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
