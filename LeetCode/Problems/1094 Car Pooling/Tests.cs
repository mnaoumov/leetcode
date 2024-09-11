namespace LeetCode.Problems._1094_Car_Pooling;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CarPooling(testCase.Trips, testCase.Capacity), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Trips { get; [UsedImplicitly] init; } = null!;
        public int Capacity { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }
    }
}
