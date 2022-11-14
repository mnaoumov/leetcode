using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode._0219_Contains_Duplicate_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ContainsNearbyDuplicate(testCase.Nums, testCase.K), Is.EqualTo(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public bool Output { get; [UsedImplicitly] init; }

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3, 1 },
                    K = 3,
                    Output = true,
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 0, 1, 1 },
                    K = 1,
                    Output = true,
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3, 1, 2, 3 },
                    K = 2,
                    Output = false,
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Nums = new[] { 99, 99 },
                    K = 2,
                    Output = true,
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}