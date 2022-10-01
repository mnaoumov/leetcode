using NUnit.Framework;

namespace LeetCode._037_Sudoku_Solver;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var board = testCase.Board.Select(row => row.ToArray()).ToArray();
        solution.SolveSudoku(board);
        Assert.That(board, Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; private init; } = null!;
        public char[][] Return { get; private init; } = null!;

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
                    Return = new[]
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
            }
        }
    }
}