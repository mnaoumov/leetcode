namespace LeetCode.Problems._0656_Coin_Path;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CheapestJump(testCase.Coins, testCase.MaxJump), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public int MaxJump { get; [UsedImplicitly] init; }
        public IList<int> Output { get; [UsedImplicitly] init; } = null!;
    }
}
