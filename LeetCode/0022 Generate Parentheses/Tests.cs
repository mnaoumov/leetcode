using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0022_Generate_Parentheses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.GenerateParenthesis(testCase.N),
            Is.EquivalentTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public string[] Output { get; [UsedImplicitly] init; } = null!;

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
