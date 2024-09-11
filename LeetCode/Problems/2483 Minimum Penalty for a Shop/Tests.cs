namespace LeetCode.Problems._2483_Minimum_Penalty_for_a_Shop;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BestClosingTime(testCase.Customers), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public string Customers { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
