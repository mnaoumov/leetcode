using NUnit.Framework;

namespace LeetCode._0050_Pow_x__n_;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MyPow(testCase.X, testCase.N), Is.EqualTo(testCase.Return).Within(1e-10));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public double X { get; private init; }
        public int N { get; private init; }
        public double Return { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 2d,
                    N = 10,
                    Return = 1024d,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = 2.1d,
                    N = 3,
                    Return = 9.261d,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 2d,
                    N = -2,
                    Return = 0.25d,
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}