namespace LeetCode._0039_Combination_Sum;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.CombinationSum(testCase.Candidates, testCase.Target), testCase.Return);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Candidates { get; private init; } = null!;
        public int Target { get; private init; }
        public IList<IList<int>> Return { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Candidates = new[] { 2, 3, 6, 7 },
                    Target = 7,
                    Return = new IList<int>[] { new[] { 2, 2, 3 }, new[] { 7 } },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Candidates = new[] { 2, 3, 5 },
                    Target = 8,
                    Return = new IList<int>[] { new[] { 2, 2, 2, 2 }, new[] { 2, 3, 3 }, new[] { 3, 5 } },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Candidates = new[] { 2 },
                    Target = 1,
                    Return = Array.Empty<IList<int>>(),
                    TestCaseName = "Example 3"
                };
            }
        }
    }
}