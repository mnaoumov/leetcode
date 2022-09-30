using NUnit.Framework;

namespace LeetCode._020_Valid_Parentheses;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsValid(testCase.S), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "()",
                    Return = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "()[]{}",
                    Return = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "(]",
                    Return = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
