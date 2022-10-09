using NUnit.Framework;

namespace LeetCode._0079_Word_Search;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Exist(testCase.Board, testCase.Word), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public char[][] Board { get; private init; } = null!;
        public string Word { get; private init; } = null!;
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Board = new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } },
                    Word = "ABCCED",
                    Return = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Board = new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } },
                    Word = "SEE",
                    Return = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Board = new[] { new[] { 'A', 'B', 'C', 'E' }, new[] { 'S', 'F', 'C', 'S' }, new[] { 'A', 'D', 'E', 'E' } },
                    Word = "ABCB",
                    Return = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}