using NUnit.Framework;

namespace LeetCode._0013_Roman_to_Integer;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.RomanToInt(testCase.S), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string S { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    S = "III",
                    Output = 3,
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    S = "LVIII",
                    Output = 58,
                    TestCaseName = "Example 2"
                };
                
                yield return new TestCase
                {
                    S = "MCMXCIV",
                    Output = 1994,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
