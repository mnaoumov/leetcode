using JetBrains.Annotations;

namespace LeetCode._0051_N_Queens;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.SolveNQueens(testCase.N), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public IList<IList<string>> Output { get; [UsedImplicitly] init; } = null!;
    }
}