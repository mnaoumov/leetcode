namespace LeetCode.Problems._3894_Traffic_Signal_Color;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TrafficSignal(testCase.Timer), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Timer { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
