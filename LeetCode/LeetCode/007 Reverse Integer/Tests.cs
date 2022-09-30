using NUnit.Framework;

namespace LeetCode._007_Reverse_Integer;

public class Tests : TestsBase2<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Reverse(testCase.X), Is.EqualTo(testCase.ExpectedResult));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int X { get; private init; }
        public int ExpectedResult { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 123,
                    ExpectedResult = 321,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = -123,
                    ExpectedResult = -321,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 120,
                    ExpectedResult = 21,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
