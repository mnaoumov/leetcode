using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0152_Maximum_Product_Subarray;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxProduct(testCase.Nums), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 2, 3, -2, 4 },
                    Output = 6,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { -2, 0, -1 },
                    Output = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 2, 3 },
                    Output = 6,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 2 },
                    Output = 2,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}