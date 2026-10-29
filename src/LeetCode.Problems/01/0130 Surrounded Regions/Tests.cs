namespace LeetCode.Problems._0130_Surrounded_Regions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var board = ArrayHelper.DeepCopy(testCase.Board);
        solution.Solve(board);
        AssertCollectionEqualWithDetails(board, testCase.OutputBoard);
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public char[][] OutputBoard { get; [UsedImplicitly] init; } = null!;
    }
}
