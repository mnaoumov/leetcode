namespace LeetCode.Problems._0499_The_Maze_III;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FindShortestWay(testCase.Maze, testCase.Ball, testCase.Hole), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Maze { get; [UsedImplicitly] init; } = null!;
        public int[] Ball { get; [UsedImplicitly] init; } = null!;
        public int[] Hole { get; [UsedImplicitly] init; } = null!;
        public string Output { get; [UsedImplicitly] init; } = null!;
    }
}
