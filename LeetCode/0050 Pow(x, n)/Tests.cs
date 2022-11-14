using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0050_Pow_x__n_;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MyPow(testCase.X, testCase.N), Is.EqualTo(testCase.Output).Within(1e-10));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public double X { get; [UsedImplicitly] init; }
        public int N { get; [UsedImplicitly] init; }
        public double Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    X = 2d,
                    N = 10,
                    Output = 1024d,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    X = 2.1d,
                    N = 3,
                    Output = 9.261d,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    X = 2d,
                    N = -2,
                    Output = 0.25d,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    X = 0.00001,
                    N = 2147483647,
                    Output = 0,
                    TestCaseName = nameof(Solution01)
                };

                yield return new TestCase
                {
                    X = 1,
                    N = 2147483647,
                    Output = 1,
                    TestCaseName = nameof(Solution02)
                };

                yield return new TestCase
                {
                    X = 2,
                    N = -2147483648,
                    Output = 0,
                    TestCaseName = nameof(Solution04)
                };

                yield return new TestCase
                {
                    X = -1,
                    N = 2147483647,
                    Output = -1,
                    TestCaseName = nameof(Solution05)
                };
            }
        }
    }
}