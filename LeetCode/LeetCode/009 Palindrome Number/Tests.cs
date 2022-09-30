using NUnit.Framework;

namespace LeetCode._009_Palindrome_Number;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPalindrome(testCase.X), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; private init; }
        public bool ExpectedResult { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 121,
                    ExpectedResult = true,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    X = -121,
                    ExpectedResult = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 10,
                    ExpectedResult = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
