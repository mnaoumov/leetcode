using NUnit.Framework;

namespace LeetCode._0017_Letter_Combinations_of_a_Phone_Number;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.LetterCombinations(testCase.Digits), Is.EquivalentTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string Digits { get; private init; } = null!;
        public string[] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Digits = "23",
                    Return = new[] { "ad", "ae", "af", "bd", "be", "bf", "cd", "ce", "cf" },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Digits = "",
                    Return = Array.Empty<string>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Digits = "2",
                    Return = new[] { "a", "b", "c" },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
