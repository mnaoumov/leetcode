namespace LeetCode.Problems._2735_Collecting_Chocolates;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinCost(testCase.Nums, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int X { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
