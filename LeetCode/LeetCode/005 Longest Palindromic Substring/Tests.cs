using NUnit.Framework;

namespace LeetCode._005_Longest_Palindromic_Substring;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LongestPalindrome(testCase.S), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public string ExpectedResult { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "babad",
                    ExpectedResult = "bab",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "cbbd",
                    ExpectedResult = "bb",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = "a",
                    ExpectedResult = "a"
                };
            }
        }
    }
}
