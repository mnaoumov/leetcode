namespace LeetCode.Problems._0490_The_Maze;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.HasPath(testCase.Maze, testCase.Start, testCase.Destination), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Maze { get; [UsedImplicitly] init; } = null!;
        public int[] Start { get; [UsedImplicitly] init; } = null!;
        public int[] Destination { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }
    }
}
