using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2461_Maximum_Sum_of_Distinct_Subarrays_With_Length_K;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaximumSubarraySum(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int K { get; private init; }
        public long Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 5, 4, 2, 9, 9, 9 },
                    K = 3,
                    Output = 15,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 4, 4, 4 },
                    K = 3,
                    Output = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
