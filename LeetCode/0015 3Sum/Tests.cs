using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0015_3Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ThreeSum(testCase.Nums),
            IsEquivalentToIgnoringItemOrder(testCase.Output));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[][] Output { get; private init; } = null!;


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { -1, 0, 1, 2, -1, -4 },
                    Output = new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 1, 1 },
                    Output = Array.Empty<int[]>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 0, 0 },
                    Output = new[] { new[] { 0, 0, 0 } },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
