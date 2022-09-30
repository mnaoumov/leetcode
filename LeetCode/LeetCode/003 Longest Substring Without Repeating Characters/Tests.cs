using NUnit.Framework;

namespace LeetCode._003_Longest_Substring_Without_Repeating_Characters;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LengthOfLongestSubstring(testCase.String), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string String { get; init; }
        public int ExpectedResult { get; init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    String = "abcabcbb",
                    ExpectedResult = 3,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    String = "bbbbb",
                    ExpectedResult = 1,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    String = "pwwkew",
                    ExpectedResult = 3,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
