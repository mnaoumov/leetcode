namespace LeetCode.Problems._1176_Diet_Plan_Performance;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DietPlanPerformance(testCase.Calories, testCase.K, testCase.Lower, testCase.Upper), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Calories { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Lower { get; [UsedImplicitly] init; }
        public int Upper { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
