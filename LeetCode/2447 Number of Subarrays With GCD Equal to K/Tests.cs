using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._2447_Number_of_Subarrays_With_GCD_Equal_to_K;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SubarrayGCD(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int K { get; private init; }
        public int Output { get; private init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 9, 3, 1, 2, 6, 3 },
                    K = 3,
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 4 },
                    K = 7,
                    Output = 0,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3, 12, 9, 6 },
                    K = 3,
                    Output = 7,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}