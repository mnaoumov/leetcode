using JetBrains.Annotations;

namespace LeetCode._0077_Combinations;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentIgnoringItemOrderWithDetails(solution.Combine(testCase.N, testCase.K), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; [UsedImplicitly] init; }
        public int K { get; [UsedImplicitly] init; }
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 4,
                    K = 2,
                    Output = new IList<int>[]
                    {
                        new[] { 1, 2 }, new[] { 1, 3 }, new[] { 1, 4 }, new[] { 2, 3 }, new[] { 2, 4 }, new[] { 3, 4 }
                    },
                    TestCaseName = "Example 1"
                };
                
                yield return new TestCase
                {
                    N = 1,
                    K = 1,
                    Output = new IList<int>[]
                    {
                        new[] { 1 }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}