using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0009_Palindrome_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IsPalindrome(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; private init; }
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 121,
                    Output = true,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    X = -121,
                    Output = false,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 10,
                    Output = false,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
