namespace LeetCode.Problems._1475_Final_Prices_With_a_Special_Discount_in_a_Shop;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FinalPrices(testCase.Prices), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Prices { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
