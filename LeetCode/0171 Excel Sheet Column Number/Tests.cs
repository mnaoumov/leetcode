using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0171_Excel_Sheet_Column_Number;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.TitleToNumber(testCase.ColumnTitle), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string ColumnTitle { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    ColumnTitle = "A",
                    Output = 1,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    ColumnTitle = "AB",
                    Output = 28,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    ColumnTitle = "ZY",
                    Output = 701,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    ColumnTitle = "ZX",
                    Output = 700,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}