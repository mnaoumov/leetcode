using JetBrains.Annotations;

namespace LeetCode._0289_Game_of_Life;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var board = ArrayHelper.DeepCopy(testCase.BoardBeforeGame);
        solution.GameOfLife(board);
        AssertCollectionEqualWithDetails(board, testCase.BoardAfterGame);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] BoardBeforeGame { get; [UsedImplicitly] init; } = null!;
        public int[][] BoardAfterGame { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    BoardBeforeGame = new[]
                    {
                        new[] { 0, 1, 0 },
                        new[] { 0, 0, 1 },
                        new[] { 1, 1, 1 },
                        new[] { 0, 0, 0 }
                    },
                    BoardAfterGame = new[]
                    {
                        new[] { 0, 0, 0 },
                        new[] { 1, 0, 1 },
                        new[] { 0, 1, 1 },
                        new[] { 0, 1, 0 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    BoardBeforeGame = new[]
                    {
                        new[] { 1, 1 },
                        new[] { 1, 0 }
                    },
                    BoardAfterGame = new[]
                    {
                        new[] { 1, 1 },
                        new[] { 1, 1 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}