using NUnit.Framework;

namespace LeetCode._0006_Zigzag_Conversion;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Convert(testCase.String, testCase.NumRows), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public string String { get; private init; } = null!;
        public int NumRows { get; private init; }
        public string Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    String = "PAYPALISHIRING",
                    NumRows = 3,
                    Return = "PAHNAPLSIIGYIR",
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    String = "PAYPALISHIRING",
                    NumRows = 4,
                    Return = "PINALSIGYAHRPI",
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    String = "A",
                    NumRows = 1,
                    Return = "A"
                };
            }
        }
    }
}
