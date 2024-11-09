namespace LeetCode.Problems._3348_Smallest_Divisible_Digit_Product_II;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SmallestNumber(testCase.Num, testCase.T), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Num { get; [UsedImplicitly] init; } = null!;
        public long T { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
