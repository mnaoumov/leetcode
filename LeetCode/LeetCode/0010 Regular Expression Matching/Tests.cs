using NUnit.Framework;

namespace LeetCode._0010_Regular_Expression_Matching;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsMatch(testCase.S, testCase.P), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string P { get; private init; } = null!;
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "aa",
                    P = "a",
                    Return = false,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "aa",
                    P = "a*",
                    Return = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "ab",
                    P = ".*",
                    Return = true,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "ab",
                    P = ".*c",
                    Return = false,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    S = "a",
                    P = "ab*a",
                    Return = false,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}
