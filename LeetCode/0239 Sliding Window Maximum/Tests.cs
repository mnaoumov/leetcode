using JetBrains.Annotations;

namespace LeetCode._0239_Sliding_Window_Maximum;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaxSlidingWindow(testCase.Nums, testCase.K), testCase.Output);
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
                    Nums = new[] { 1, 3, -1, -3, 5, 3, 6, 7 },
                    K = 3,
                    Output = new[] { 3, 3, 5, 5, 6, 7 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    K = 1,
                    Output = new[] { 1 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = Array.Empty<int>(),
                    K = 0,
                    Output = Array.Empty<int>(),
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}