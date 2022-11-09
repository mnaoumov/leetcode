using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0135_Candy;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.Candy(testCase.Ratings), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Ratings { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Ratings = new[] { 1, 0, 2 },
                    Output = 5,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Ratings = new[] { 1, 2, 2 },
                    Output = 4,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Ratings = new[] { 1, 3, 4, 5, 2 },
                    Output = 11,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Ratings = new[] { 1, 2, 87, 87, 87, 2, 1 },
                    Output = 13,
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Ratings = new[] { 29, 51, 87, 87, 72, 12 },
                    Output = 12,
                    TestCaseName = nameof(Solution3)
                };

                yield return new TestCase
                {
                    Ratings = new[] { 1, 6, 10, 8, 7, 3, 2 },
                    Output = 18,
                    TestCaseName = nameof(Solution4)
                };
            }
        }
    }
}
