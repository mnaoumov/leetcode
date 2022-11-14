using JetBrains.Annotations;

namespace LeetCode._0301_Remove_Invalid_Parentheses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.RemoveInvalidParentheses(testCase.S), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public IList<string> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "()())()",
                    Output = new[] { "(())()", "()()()" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "(a)())()",
                    Output = new[] { "(a())()", "(a)()()" },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = ")(",
                    Output = new[] { "" },
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "(()((()d)o",
                    Output = new[] { "()(()d)o", "(()()d)o" },
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}