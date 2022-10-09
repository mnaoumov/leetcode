using NUnit.Framework;

namespace LeetCode._0013_Roman_to_Integer;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RomanToInt(testCase.S), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "III",
                    Return = 3,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    S = "LVIII",
                    Return = 58,
                    TestCaseName = "Example 2"
                };
                
                yield return new TestCase
                {
                    S = "MCMXCIV",
                    Return = 1994,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
