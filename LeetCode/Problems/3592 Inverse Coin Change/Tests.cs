namespace LeetCode.Problems._3592_Inverse_Coin_Change;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindCoins(testCase.NumWays), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] NumWays { get; [UsedImplicitly] init; } = null!;
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
