namespace LeetCode.Problems._2431_Maximize_Total_Tastiness_of_Purchased_Fruits;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxTastiness(testCase.Price, testCase.Tastiness, testCase.MaxAmount, testCase.MaxCoupons), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Price { get; [UsedImplicitly] init; } = null!;
        public int[] Tastiness { get; [UsedImplicitly] init; } = null!;
        public int MaxAmount { get; [UsedImplicitly] init; }
        public int MaxCoupons { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
