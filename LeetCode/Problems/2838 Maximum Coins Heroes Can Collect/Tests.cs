namespace LeetCode.Problems._2838_Maximum_Coins_Heroes_Can_Collect;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaximumCoins(testCase.Heroes, testCase.Monsters, testCase.Coins), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Heroes { get; [UsedImplicitly] init; } = null!;
        public int[] Monsters { get; [UsedImplicitly] init; } = null!;
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public long[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
