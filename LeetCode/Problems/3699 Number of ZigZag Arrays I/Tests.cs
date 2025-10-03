namespace LeetCode.Problems._3699_Number_of_ZigZag_Arrays_I;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ZigZagArrays(testCase.N, testCase.L, testCase.R), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int L { get; [UsedImplicitly] init; }
        public int R { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
