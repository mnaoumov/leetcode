using NUnit.Framework;
namespace LeetCode._022_Generate_Parentheses;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateParenthesis(testCase.N),
            Is.EquivalentTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public string[] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    Return = new[] { "((()))", "(()())", "(())()", "()(())", "()()()" },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    N = 1,
                    Return = new[] { "()" },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
