using NUnit.Framework;

namespace LeetCode._0171_Excel_Sheet_Column_Number;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TitleToNumber(testCase.ColumnTitle), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string ColumnTitle { get; private init; } = null!;
        public int Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    ColumnTitle = "A",
                    Return = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    ColumnTitle = "AB",
                    Return = 28,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    ColumnTitle = "ZY",
                    Return = 701,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    ColumnTitle = "ZX",
                    Return = 700,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}