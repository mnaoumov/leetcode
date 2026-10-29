namespace LeetCode.Problems._3468_Find_the_Number_of_Copy_Arrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountArrays(testCase.Original, testCase.Bounds), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Original { get; [UsedImplicitly] init; } = null!;
        public int[][] Bounds { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
