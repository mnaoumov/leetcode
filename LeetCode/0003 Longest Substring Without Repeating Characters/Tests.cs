using NUnit.Framework;

namespace LeetCode._0003_Longest_Substring_Without_Repeating_Characters;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LengthOfLongestSubstring(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "abcabcbb",
                    Output = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "bbbbb",
                    Output = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "pwwkew",
                    Output = 3,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "opachvf",
                    Output = 7,
                    TestCaseName = nameof(Solution3_9)
                };

                yield return new TestCase
                {
                    S = "",
                    Output = 0,
                    TestCaseName = nameof(Solution6)
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    S = "tmmzuxt",
                    Output = 5,
                    TestCaseName = nameof(Solution3_9)
                };
            }
        }
    }
}
