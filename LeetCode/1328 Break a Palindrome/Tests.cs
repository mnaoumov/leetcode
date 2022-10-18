using NUnit.Framework;

namespace LeetCode._1328_Break_a_Palindrome;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.BreakPalindrome(testCase.Palindrome), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Palindrome { get; private init; } = null!;
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    Palindrome = "abccba",
                    // ReSharper disable once StringLiteralTypo
                    Output = "aaccba",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Palindrome = "a",
                    Output = "",
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}