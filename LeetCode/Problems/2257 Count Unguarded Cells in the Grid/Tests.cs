namespace LeetCode.Problems._2257_Count_Unguarded_Cells_in_the_Grid;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CountUnguarded(testCase.M, testCase.N, testCase.Guards, testCase.Walls), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int M { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public int[][] Guards { get; [UsedImplicitly] init; } = null!;
        public int[][] Walls { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }
    }
}
