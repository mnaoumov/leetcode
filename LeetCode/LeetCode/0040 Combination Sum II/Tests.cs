namespace LeetCode._0040_Combination_Sum_II;

public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.CombinationSum2(testCase.Candidates, testCase.Target), testCase.Return);
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
                    Candidates = new[] { 10, 1, 2, 7, 6, 1, 5 },
                    Target = 8,
                    Return = new IList<int>[]
                    {
                        new[] { 1, 1, 6 },
                        new[] { 1, 2, 5 },
                        new[] { 1, 7 },
                        new[] { 2, 6 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Candidates = new[] { 2, 5, 5, 2, 1, 2 },
                    Target = 5,
                    Return = new IList<int>[]
                    {
                        new[] { 1, 2, 2 },
                        new[] { 5 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}