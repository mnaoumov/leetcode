using JetBrains.Annotations;

namespace LeetCode._0051_N_Queens;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.SolveNQueens(testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int N { get; private init; }
        public IList<IList<string>> Output { get; private init; } = null!;

        public override IEnumerable<TestCase> TestCases
        {
            get
            {
                yield return new TestCase
                {
                    N = 4,
                    Output = new IList<string>[]
                    {
                        new[] { ".Q..", "...Q", "Q...", "..Q." },
                        new[] { "..Q.", "Q...", "...Q", ".Q.." }
                    },
                    TestCaseName = "Example 1"
                };

                yield return new TestCase
                {
                    N = 1,
                    Output = new IList<string>[]
                    {
                        new[] { "Q" }
                    },
                    TestCaseName = "Example 2"
                };
            }
        }
    }
}