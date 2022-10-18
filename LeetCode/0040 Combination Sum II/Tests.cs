using JetBrains.Annotations;

namespace LeetCode._0040_Combination_Sum_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.CombinationSum2(testCase.Candidates, testCase.Target), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Candidates { get; private init; } = null!;
        public int Target { get; private init; }
        public IList<IList<int>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Candidates = new[] { 10, 1, 2, 7, 6, 1, 5 },
                    Target = 8,
                    Output = new IList<int>[]
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
                    Output = new IList<int>[]
                    {
                        new[] { 1, 2, 2 },
                        new[] { 5 }
                    },
                    TestCaseName = "Example 2"
                };

                yield return new TestCase
                {
                    Candidates = new[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    Target = 27,
                    Output = Array.Empty<IList<int>>(),
                    TestCaseName = nameof(Solution1)
                };

                yield return new TestCase
                {
                    Candidates = new[]
                    {
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
                        1, 1, 1, 1
                    },
                    Target = 30,
                    Output = new IList<int>[]
                    {
                        new[]
                        {
                            1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1
                        }
                    },

                    TestCaseName = nameof(Solution2)
                };
            }
        }
    }
}