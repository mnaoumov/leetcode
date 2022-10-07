using NUnit.Framework;

namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LengthOfLongestSubstring(testCase.S), Is.EqualTo(testCase.Return));
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
                    S = "abcabcbb",
                    Return = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "bbbbb",
                    Return = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "pwwkew",
                    Return = 3,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    S = "opachvf",
                    Return = 7,
                    TestCaseName = nameof(Solution3_9)
                };

                yield return new TestCase
                {
                    S = "",
                    Return = 0,
                    TestCaseName = nameof(Solution6)
                };

                yield return new TestCase
                {
                    S = "tmmzuxt",
                    Return = 5,
                    TestCaseName = nameof(Solution3_9)
                };
            }
        }
    }
}
