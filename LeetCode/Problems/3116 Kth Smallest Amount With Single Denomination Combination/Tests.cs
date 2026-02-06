namespace LeetCode.Problems._3116_Kth_Smallest_Amount_With_Single_Denomination_Combination;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindKthSmallest(testCase.Coins, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Coins { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
