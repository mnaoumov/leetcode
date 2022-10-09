using NUnit.Framework;

namespace LeetCode._0007_Reverse_Integer;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Reverse(testCase.X), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 123,
                    Output = 321,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = -123,
                    Output = -321,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 120,
                    Output = 21,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    X = -2147483648,
                    Output = 0,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
