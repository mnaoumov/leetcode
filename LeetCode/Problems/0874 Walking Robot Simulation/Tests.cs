namespace LeetCode.Problems._0874_Walking_Robot_Simulation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RobotSim(testCase.Commands, testCase.Obstacles), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Commands { get; [UsedImplicitly] init; } = null!;
        public int[][] Obstacles { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
