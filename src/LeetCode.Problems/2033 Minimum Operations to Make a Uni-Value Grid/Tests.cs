namespace LeetCode.Problems._2033_Minimum_Operations_to_Make_a_Uni_Value_Grid;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MinOperations(testCase.Grid, testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Grid { get; [UsedImplicitly] init; } = null!;
        public int X { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }
    }
}
