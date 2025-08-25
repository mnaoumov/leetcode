namespace LeetCode.Problems._2106_Maximum_Fruits_Harvested_After_at_Most_K_Steps;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxTotalFruits(testCase.Fruits, testCase.StartPos, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Fruits { get; [UsedImplicitly] init; } = null!;
        public int StartPos { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
