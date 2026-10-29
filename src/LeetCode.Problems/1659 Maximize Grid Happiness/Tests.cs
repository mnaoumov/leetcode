namespace LeetCode.Problems._1659_Maximize_Grid_Happiness;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GetMaxGridHappiness(testCase.M, testCase.N, testCase.IntrovertsCount, testCase.ExtrovertsCount), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int IntrovertsCount { get; [UsedImplicitly] init; }
        public int ExtrovertsCount { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
