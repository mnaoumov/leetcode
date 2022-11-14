using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._6234_Number_of_Subarrays_With_LCM_Equal_to_K;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.SubarrayLCM(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 3, 6, 2, 7, 1 },
                    K = 6,
                    Output = 4,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3 },
                    K = 2,
                    Output = 0,
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}
