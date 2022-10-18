using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0020_Valid_Parentheses;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsValid(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "()",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "()[]{}",
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "(]",
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
