using NUnit.Framework;

namespace LeetCode._032_Longest_Valid_Parentheses;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestValidParentheses(testCase.S), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "(()",
                    Return = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = ")()())",
                    Return = 4,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "",
                    Return = 0,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}