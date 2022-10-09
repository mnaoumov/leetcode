namespace LeetCode._0301_Remove_Invalid_Parentheses;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RemoveInvalidParentheses(testCase.S), testCase.Return);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public IList<string> Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "()())()",
                    Return = new[] { "(())()", "()()()" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "(a)())()",
                    Return = new[] { "(a())()", "(a)()()" },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = ")(",
                    Return = new[] { "" },
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "(()((()d)o",
                    Return = new[] { "()(()d)o", "(()()d)o" },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}