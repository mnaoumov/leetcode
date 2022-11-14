using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._2131_Longest_Palindrome_by_Concatenating_Two_Letter_Words;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestPalindrome(testCase.Words), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string[] Words { get; [UsedImplicitly] init; } = null!;
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Words = new[] { "lc", "cl", "gg" },
                    Output = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Words = new[] { "ab", "ty", "yt", "lc", "cl", "ab" },
                    Output = 8,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Words = new[] { "cc", "ll", "xx" },
                    Output = 2,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
