using NUnit.Framework;

namespace LeetCode._0015_3Sum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ThreeSum(testCase.Nums),
            IsEquivalentToIgnoringItemOrder(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int[][] Return { get; private init; } = null!;


        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { -1, 0, 1, 2, -1, -4 },
                    Return = new[] { new[] { -1, -1, 2 }, new[] { -1, 0, 1 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 1, 1 },
                    Return = Array.Empty<int[]>(),
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, 0, 0 },
                    Return = new[] { new[] { 0, 0, 0 } },
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}
