using JetBrains.Annotations;

namespace LeetCode._0090_Subsets_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.SubsetsWithDup(testCase.Nums), testCase.Output);
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
                    Nums = new[] { 1, 2, 2, },
                    Output = new IList<int>[]
                    {
                        Array.Empty<int>(), new[] { 1 }, new[] { 1, 2 }, new[] { 1, 2, 2 }, new[] { 2 }, new[] { 2, 2 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0, },
                    Output = new IList<int>[]
                    {
                        Array.Empty<int>(), new[] { 0 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}