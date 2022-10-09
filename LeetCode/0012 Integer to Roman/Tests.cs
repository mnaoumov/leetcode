using NUnit.Framework;

namespace LeetCode._0012_Integer_to_Roman;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.IntToRoman(testCase.Num), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int Num { get; private init; }
        public string Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Num = 3,
                    Output = "III",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Num = 58,
                    Output = "LVIII",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Num = 1994,
                    Output = "MCMXCIV",
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
