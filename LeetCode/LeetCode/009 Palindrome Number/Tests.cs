using NUnit.Framework;

namespace LeetCode._009_Palindrome_Number;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPalindrome(testCase.X), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; private init; }
        public bool Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 121,
                    Return = true,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    X = -121,
                    Return = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 10,
                    Return = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
