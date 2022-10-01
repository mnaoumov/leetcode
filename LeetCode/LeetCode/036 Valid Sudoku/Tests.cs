using NUnit.Framework;

namespace LeetCode._036_Valid_Sudoku;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsValidSudoku(testCase.Board), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; private init; } = null!;
        public bool Return { get; private init; }

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
                    Return = true,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { '8', '3', '.', '.', '7', '.', '.', '.', '.' },
                        new[] { '6', '.', '.', '1', '9', '5', '.', '.', '.' },
                        new[] { '.', '9', '8', '.', '.', '.', '.', '6', '.' },
                        new[] { '8', '.', '.', '.', '6', '.', '.', '.', '3' },
                        new[] { '4', '.', '.', '8', '.', '3', '.', '.', '1' },
                        new[] { '7', '.', '.', '.', '2', '.', '.', '.', '6' },
                        new[] { '.', '6', '.', '.', '.', '.', '2', '8', '.' },
                        new[] { '.', '.', '.', '4', '1', '9', '.', '.', '5' },
                        new[] { '.', '.', '.', '.', '8', '.', '.', '7', '9' }
                    },
                    Return = false,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}