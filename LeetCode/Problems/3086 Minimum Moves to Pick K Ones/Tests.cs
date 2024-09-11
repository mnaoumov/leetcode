namespace LeetCode.Problems._3086_Minimum_Moves_to_Pick_K_Ones;

[UsedImplicitly]
[Category("TODO")]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinimumMoves(testCase.Nums, testCase.K, testCase.MaxChanges), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int MaxChanges { get; [UsedImplicitly] init; }
        public long Output { get; [UsedImplicitly] init; }
    }
}
