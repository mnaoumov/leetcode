namespace LeetCode.Problems._0505_The_Maze_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ShortestDistance(testCase.Maze, testCase.Start, testCase.Destination), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Maze { get; [UsedImplicitly] init; } = null!;
        public int[] Start { get; [UsedImplicitly] init; } = null!;
        public int[] Destination { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
