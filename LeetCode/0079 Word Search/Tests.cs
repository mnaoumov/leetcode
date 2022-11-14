using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0079_Word_Search;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Exist(testCase.Board, testCase.Word), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; [UsedImplicitly] init; } = null!;
        public string Word { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Board = new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } },
                    // ReSharper disable once StringLiteralTypo
                    Word = "ABCCED",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Board = new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } },
                    Word = "SEE",
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Board = new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } },
                    // ReSharper disable once StringLiteralTypo
                    Word = "ABCB",
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}