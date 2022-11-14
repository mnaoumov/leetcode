using JetBrains.Annotations;

namespace LeetCode._0130_Surrounded_Regions;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var board = ArrayHelper.DeepCopy(testCase.Board);
        solution.Solve(board);
        AssertCollectionEqualWithDetails(board, testCase.OutputBoard);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public char[][] OutputBoard { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'X', 'X', 'X', 'X' }, new[] { 'X', 'O', 'O', 'X' }, new[] { 'X', 'X', 'O', 'X' }, new[] { 'X', 'O', 'X', 'X' }
                    },
                    OutputBoard = new[]
                    {
                        new[] { 'X', 'X', 'X', 'X' }, new[] { 'X', 'X', 'X', 'X' }, new[] { 'X', 'X', 'X', 'X' }, new[] { 'X', 'O', 'X', 'X' }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'X' }
                    },
                    OutputBoard = new[]
                    {
                        new[] { 'X' }
                    },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'X', 'O', 'X' }, new[] { 'X', 'O', 'X' }, new[] { 'X', 'O', 'X' }
                    },
                    OutputBoard = new[]
                    {
                        new[] { 'X', 'O', 'X' }, new[] { 'X', 'O', 'X' }, new[] { 'X', 'O', 'X' }
                    },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Board = new[]
                    {
                        new[] { 'O', 'X', 'X', 'O', 'X' }, new[] { 'X', 'O', 'O', 'X', 'O' },
                        new[] { 'X', 'O', 'X', 'O', 'X' }, new[] { 'O', 'X', 'O', 'O', 'O' },
                        new[] { 'X', 'X', 'O', 'X', 'O' }
                    },
                    OutputBoard = new[]
                    {
                        new[] { 'O', 'X', 'X', 'O', 'X' }, new[] { 'X', 'X', 'X', 'X', 'O' },
                        new[] { 'X', 'X', 'X', 'O', 'X' }, new[] { 'O', 'X', 'O', 'O', 'O' },
                        new[] { 'X', 'X', 'O', 'X', 'O' }
                    },
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
