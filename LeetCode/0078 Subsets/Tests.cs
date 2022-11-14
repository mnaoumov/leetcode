using JetBrains.Annotations;

namespace LeetCode._0078_Subsets;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.Subsets(testCase.Nums), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Nums { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    Nums = new[] { 1, 2, 3 },
                    Output = new IList<int>[]
                    {
                        Array.Empty<int>(), new[] { 1 }, new[] { 2 }, new[] { 1, 2 }, new[] { 3 }, new[] { 1, 3 },
                        new[] { 2, 3 }, new[] { 1, 2, 3 }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    Nums = new[] { 0 },
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