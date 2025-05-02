namespace LeetCode.Problems._2145_Count_the_Hidden_Sequences;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumberOfArrays(testCase.Differences, testCase.Lower, testCase.Upper), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Differences { get; [UsedImplicitly] init; } = null!;
        public int Lower { get; [UsedImplicitly] init; }
        public int Upper { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
