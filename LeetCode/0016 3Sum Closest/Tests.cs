using NUnit.Framework;

namespace LeetCode._0016_3Sum_Closest;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ThreeSumClosest(testCase.Nums, testCase.Target), Is.EqualTo(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int Return { get; private init; }


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { -1, 2, 1, -4 },
                    Target = 1,
                    Return = 2,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 0, 0 },
                    Target = 1,
                    Return = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[]
                    {
                        -23, -67, 32, 21, -65, 46, 73, 42, 93, 9, -61, -79, -51, 61, -15, 49, 92, -34, 50, 1, 26, -12,
                        68,
                        -97, -17, 51, -55, 75, -56, -95, -70, -42, 91, -18, -64, 20, 33, -20, 19, 61, -89, 81, -73, 82,
                        -23,
                        -65, 51, -88, 15, -48, 24, 34, 0, -24, 37, 22, 28, -67, -25, -61, -57, -74, 65, 50, -66, 24, 99,
                        80,
                        44, 85, 20, -4, -9, -81, 87, -82, -100, 51, -83, 9, -31, 37, 23, -61, 53, -14, -51, 88, 56, 27,
                        42,
                        -52, -97, 37, 36, -59, -45, 95, 46, -1, -100, -38, 66, 44, 27, -97, 12, -43, 84, -53, 93, 18,
                        -40,
                        -38, 34, 85, 53, -50, -14, -6, 98, -77, -17, 50, -65, 52, -46, -94, 49, 72, -2, -82, 45, -39,
                        -58,
                        67, 82, 63, 95, -32, 47, 15, -20, 46, 5, 17, -40, -95, 97, -9, 11, 8, -51, -24, -50, -37, -72,
                        -57,
                        26, 26, 19, 71, -42
                    },
                    Target = -87,
                    Return = -87,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
