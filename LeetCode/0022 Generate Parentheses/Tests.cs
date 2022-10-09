using NUnit.Framework;

namespace LeetCode._0022_Generate_Parentheses;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateParenthesis(testCase.N),
            Is.EquivalentTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public string[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    Output = new[] { "((()))", "(()())", "(())()", "()(())", "()()()" },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    N = 1,
                    Output = new[] { "()" },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
