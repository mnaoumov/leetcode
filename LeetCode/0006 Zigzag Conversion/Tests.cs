using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0006_Zigzag_Conversion;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Convert(testCase.String, testCase.NumRows), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string String { get; [UsedImplicitly] init; } = null!;
        public int NumRows { get; [UsedImplicitly] init; }
        public string Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    String = "PAYPALISHIRING",
                    NumRows = 3,
                    // ReSharper disable once StringLiteralTypo
                    Output = "PAHNAPLSIIGYIR",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    // ReSharper disable once StringLiteralTypo
                    String = "PAYPALISHIRING",
                    NumRows = 4,
                    // ReSharper disable once StringLiteralTypo
                    Output = "PINALSIGYAHRPI",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    String = "A",
                    NumRows = 1,
                    Output = "A",
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
