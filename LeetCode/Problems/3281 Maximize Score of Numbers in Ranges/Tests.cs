namespace LeetCode.Problems._3281_Maximize_Score_of_Numbers_in_Ranges;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxPossibleScore(testCase.Start, testCase.D), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Start { get; [UsedImplicitly] init; } = null!;
        public int D { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
