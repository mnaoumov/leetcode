using NUnit.Framework;

namespace LeetCode._018_4Sum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.FourSum(testCase.Nums, testCase.Target),
            IsEquivalentToIgnoringItemOrder(testCase.Return));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int[][] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 0, -1, 0, -2, 2 },
                    Target = 0,
                    Return = new[] { new[] { -2, -1, 1, 2 }, new[] { -2, 0, 0, 2 }, new[] { -1, 0, 0, 1 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 2, 2, 2, 2, 2 },
                    Target = 8,
                    Return = new[] { new[] { 2, 2, 2, 2 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1000000000, 1000000000, 1000000000, 1000000000 },
                    Target = -294967296,
                    Return = Array.Empty<int[]>()
                };
            }
        }
    }
}
