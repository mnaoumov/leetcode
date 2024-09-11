namespace LeetCode.Problems._0037_Sudoku_Solver;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var board = ArrayHelper.DeepCopy(testCase.Board);
        solution.SolveSudoku(board);
        AssertCollectionEqualWithDetails(board, testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public char[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
