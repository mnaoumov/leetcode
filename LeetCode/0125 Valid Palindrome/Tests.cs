using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0125_Valid_Palindrome;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPalindrome(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; [UsedImplicitly] init; } = null!;
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "A man, a plan, a canal: Panama",
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    S = "race a car",
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    S = " ",
                    Output = true,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
