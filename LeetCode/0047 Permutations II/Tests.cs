using JetBrains.Annotations;

namespace LeetCode._0047_Permutations_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.PermuteUnique(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; private init; } = null!;
        public IList<IList<int>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 1, 2 },
                    Output = new IList<int>[]
                    {
                        new[] { 1, 1, 2 },
                        new[] { 1, 2, 1 },
                        new[] { 2, 1, 1 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3 },
                    Output = new IList<int>[]
                    {
                        new[] { 1, 2, 3 },
                        new[] { 1, 3, 2 },
                        new[] { 2, 1, 3 },
                        new[] { 2, 3, 1 },
                        new[] { 3, 1, 2 },
                        new[] { 3, 2, 1 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}