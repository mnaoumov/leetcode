using JetBrains.Annotations;

namespace LeetCode._0001_Two_Sum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.TwoSum(testCase.Nums, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int Target { get; private init; }
        public int[] Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 2, 7, 11, 15 },
                    Target = 9,
                    Output = new[] { 0, 1 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3, 2, 4, 6 },
                    Target = 6,
                    Output = new[] { 1, 2 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = new[] { 3, 3 },
                    Target = 6,
                    Output = new[] { 0, 1 },
                    TestCaseName = "Example 3"
                };

                yield return new TestCase
                {
                    Nums = new[] { -1, -2, -3, -4, -5 },
                    Target = -8,
                    Output = new[] { 2, 4 },
                    TestCaseName = nameof(Solution7)
                };
            }
        }
    }
}