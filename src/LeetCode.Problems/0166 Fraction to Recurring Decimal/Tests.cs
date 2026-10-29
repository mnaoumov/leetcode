namespace LeetCode.Problems._0166_Fraction_to_Recurring_Decimal;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FractionToDecimal(testCase.Numerator, testCase.Denominator), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Numerator { get; [UsedImplicitly] init; }
        public int Denominator { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
