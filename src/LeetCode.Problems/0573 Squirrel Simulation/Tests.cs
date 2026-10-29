namespace LeetCode.Problems._0573_Squirrel_Simulation;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinDistance(testCase.Height, testCase.Width, testCase.Tree, testCase.Squirrel, testCase.Nuts), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int Height { get; [UsedImplicitly] init; }
        public int Width { get; [UsedImplicitly] init; }
        public int[] Tree { get; [UsedImplicitly] init; } = null!;
        public int[] Squirrel { get; [UsedImplicitly] init; } = null!;
        public int[][] Nuts { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
