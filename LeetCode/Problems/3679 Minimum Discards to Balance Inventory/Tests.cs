namespace LeetCode.Problems._3679_Minimum_Discards_to_Balance_Inventory;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinArrivalsToDiscard(testCase.Arrivals, testCase.W, testCase.M), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Arrivals { get; [UsedImplicitly] init; } = null!;
        public int W { get; [UsedImplicitly] init; }
        public int M { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
