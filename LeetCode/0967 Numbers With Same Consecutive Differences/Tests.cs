using NUnit.Framework;

namespace LeetCode._0967_Numbers_With_Same_Consecutive_Differences;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.NumsSameConsecDiff(testCase.N, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public int K { get; private init; }
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 3,
                    K = 7,
                    Output = new[] { 181, 292, 707, 818, 929 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 2,
                    K = 1,
                    Output = new[] { 10, 12, 21, 23, 32, 34, 43, 45, 54, 56, 65, 67, 76, 78, 87, 89, 98 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    N = 2,
                    K = 0,
                    Output = new[] { 11, 22, 33, 44, 55, 66, 77, 88, 99 },
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    N = 3,
                    K = 1,
                    Output = new[]
                    {
                        101, 121, 123, 210, 212, 232, 234, 321, 323, 343, 345, 432, 434, 454, 456, 543, 545, 565, 567,
                        654, 656, 676, 678, 765, 767, 787, 789, 876, 878, 898, 987, 989
                    },
                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}