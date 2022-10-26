using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0523_Continuous_Subarray_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.CheckSubarraySum(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int K { get; private init; }
        public bool Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 23, 2, 4, 6, 7 },
                    K = 6,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 23, 2, 6, 4, 7 },
                    K = 6,
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 23, 2, 6, 4, 7 },
                    K = 13,
                    Output = false,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Nums = new[] { 23, 2, 4, 6, 6 },
                    K = 7,
                    Output = true,
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 0 },
                    K = 2,
                    Output = false,
                    TestCaseName = nameof(Solution2)
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 0, 1, 0, 1 },
                    K = 4,
                    Output = false,
                    TestCaseName = nameof(Solution3)
                };
            }
        }
    }
}