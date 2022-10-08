using NUnit.Framework;

namespace LeetCode._0044_Wildcard_Matching;

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
                    P = "*",
                    Return = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "cb",
                    P = "?a",
                    Return = false,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "bbbbbbbabbaabbabbbbaaabbabbabaaabbababbbabbbabaaabaab",
                    P = "b*b*ab**ba*b**b***bba",
                    Return = false,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    S = "abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb",
                    P = "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb",
                    Return = false,
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}