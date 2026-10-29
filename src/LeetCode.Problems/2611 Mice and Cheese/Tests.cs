namespace LeetCode.Problems._2611_Mice_and_Cheese;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MiceAndCheese(testCase.Reward1, testCase.Reward2, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Reward1 { get; [UsedImplicitly] init; } = null!;
        public int[] Reward2 { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
