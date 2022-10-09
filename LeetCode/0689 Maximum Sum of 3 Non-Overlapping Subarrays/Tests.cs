using NUnit.Framework;

namespace LeetCode._0689_Maximum_Sum_of_3_Non_Overlapping_Subarrays;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MaxSumOfThreeSubarrays(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int K { get; private init; }
        public int[] Output { get; private init; } = null!;


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