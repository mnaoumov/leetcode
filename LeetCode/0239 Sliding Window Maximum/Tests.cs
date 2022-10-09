namespace LeetCode._0239_Sliding_Window_Maximum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MaxSlidingWindow(testCase.Nums, testCase.K), testCase.Return);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public int K { get; private init; }
        public int[] Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 3, -1, -3, 5, 3, 6, 7 },
                    K = 3,
                    Return = new[] { 3, 3, 5, 5, 6, 7 },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1 },
                    K = 1,
                    Return = new[] { 1 },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Nums = Array.Empty<int>(),
                    K = 0,
                    Return = Array.Empty<int>(),
                    TestCaseName = nameof(Solution1)
                };
            }
        }
    }
}