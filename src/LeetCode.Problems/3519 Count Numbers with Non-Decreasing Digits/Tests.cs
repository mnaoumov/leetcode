namespace LeetCode.Problems._3519_Count_Numbers_with_Non_Decreasing_Digits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountNumbers(testCase.L, testCase.R, testCase.B), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string L { get; [UsedImplicitly] init; } = null!;
        public string R { get; [UsedImplicitly] init; } = null!;
        public int B { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
