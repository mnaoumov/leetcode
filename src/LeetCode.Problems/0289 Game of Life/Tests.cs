namespace LeetCode.Problems._0289_Game_of_Life;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        var board = ArrayHelper.DeepCopy(testCase.BoardBeforeGame);
        solution.GameOfLife(board);
        AssertCollectionEqualWithDetails(board, testCase.BoardAfterGame);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] BoardBeforeGame { get; [UsedImplicitly] init; } = null!;
        public int[][] BoardAfterGame { get; [UsedImplicitly] init; } = null!;
    }
}
