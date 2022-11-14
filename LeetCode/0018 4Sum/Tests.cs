using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0018_4Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FourSum(testCase.Nums, testCase.Target),
            IsEquivalentToIgnoringItemOrder(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public int Target { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 0, -1, 0, -2, 2 },
                    Target = 0,
                    Output = new[] { new[] { -2, -1, 1, 2 }, new[] { -2, 0, 0, 2 }, new[] { -1, 0, 0, 1 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 2, 2, 2, 2, 2 },
                    Target = 8,
                    Output = new[] { new[] { 2, 2, 2, 2 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1000000000, 1000000000, 1000000000, 1000000000 },
                    Target = -294967296,
                    Output = Array.Empty<int[]>(),
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}
