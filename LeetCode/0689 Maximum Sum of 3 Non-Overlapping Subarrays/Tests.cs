using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0689_Maximum_Sum_of_3_Non_Overlapping_Subarrays;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSumOfThreeSubarrays(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[] Output { get; [UsedImplicitly] init; } = null!;


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 1, 2, 6, 7, 5, 1 },
                    K = 2,
                    Output = new[] { 0, 3, 5 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 1, 2, 1, 2, 1, 2, 1 },
                    K = 2,
                    Output = new[] { 0, 2, 4 },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}