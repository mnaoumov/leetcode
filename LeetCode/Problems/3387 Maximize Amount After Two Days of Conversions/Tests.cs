namespace LeetCode.Problems._3387_Maximize_Amount_After_Two_Days_of_Conversions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxAmount(testCase.InitialCurrency, testCase.Pairs1, testCase.Rates1, testCase.Pairs2, testCase.Rates2), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string InitialCurrency { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Pairs1 { get; [UsedImplicitly] init; } = null!;
        public double[] Rates1 { get; [UsedImplicitly] init; } = null!;
        public IList<IList<string>> Pairs2 { get; [UsedImplicitly] init; } = null!;
        public double[] Rates2 { get; [UsedImplicitly] init; } = null!;
        public double Output { get; [UsedImplicitly] init; }
    }
}
