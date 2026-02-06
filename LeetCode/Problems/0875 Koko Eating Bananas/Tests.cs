namespace LeetCode.Problems._0875_Koko_Eating_Bananas;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinEatingSpeed(testCase.Piles, testCase.H), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Piles { get; [UsedImplicitly] init; } = null!;
        public int H { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
