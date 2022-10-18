using JetBrains.Annotations;

namespace LeetCode._0037_Sudoku_Solver;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var board = ArrayHelper.DeepCopy(testCase.Board);
        solution.SolveSudoku(board);
        AssertCollectionEqualWithDetails(board, testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; private init; } = null!;
        public char[][] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { '5', '3', '.', '.', '7', '.', '.', '.', '.' },
                        new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                        new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                        new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                        new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                        new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                        new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                        new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                        new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                    },
                    Output = new[]
                    {
                        new[] { '5', '3', '4', '6', '7', '8', '9', '1', '2' },
                        new[] { '6', '7', '2', '1', '9', '5', '3', '4', '8' },
                        new[] { '1', '9', '8', '3', '4', '2', '5', '6', '7' },
                        new[] { '8', '5', '9', '7', '6', '1', '4', '2', '3' },
                        new[] { '4', '2', '6', '8', '5', '3', '7', '9', '1' },
                        new[] { '7', '1', '3', '9', '2', '4', '8', '5', '6' },
                        new[] { '9', '6', '1', '5', '3', '7', '2', '8', '4' },
                        new[] { '2', '8', '7', '4', '1', '9', '6', '3', '5' },
                        new[] { '3', '4', '5', '2', '8', '6', '1', '7', '9' }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { '.', '.', '9', '7', '4', '8', '.', '.', '.' },
                        new[] { '7', '.', '.', '.', '.', '.', '.', '.', '.' },
                        new[] { '.', '2', '.', '1', '.', '9', '.', '.', '.' },
                        new[] { '.', '.', '7', '.', '.', '.', '2', '4', '.' },
                        new[] { '.', '6', '4', '.', '1', '.', '5', '9', '.' },
                        new[] { '.', '9', '8', '.', '.', '.', '3', '.', '.' },
                        new[] { '.', '.', '.', '8', '.', '3', '.', '2', '.' },
                        new[] { '.', '.', '.', '.', '.', '.', '.', '.', '6' },
                        new[] { '.', '.', '.', '2', '7', '5', '9', '.', '.' }
                    },
                    Output = new[]
                    {
                        new[] { '5', '1', '9', '7', '4', '8', '6', '3', '2' },
                        new[] { '7', '8', '3', '6', '5', '2', '4', '1', '9' },
                        new[] { '4', '2', '6', '1', '3', '9', '8', '7', '5' },
                        new[] { '3', '5', '7', '9', '8', '6', '2', '4', '1' },
                        new[] { '2', '6', '4', '3', '1', '7', '5', '9', '8' },
                        new[] { '1', '9', '8', '5', '2', '4', '3', '6', '7' },
                        new[] { '9', '7', '5', '8', '6', '3', '1', '2', '4' },
                        new[] { '8', '3', '2', '4', '9', '1', '7', '5', '6' },
                        new[] { '6', '4', '1', '2', '7', '5', '9', '8', '3' }
                    },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}