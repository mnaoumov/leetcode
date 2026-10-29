namespace LeetCode.Problems._2706_Buy_Two_Chocolates;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BuyChoco(testCase.Prices, testCase.Money), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Prices { get; [UsedImplicitly] init; } = null!;
        public int Money { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
