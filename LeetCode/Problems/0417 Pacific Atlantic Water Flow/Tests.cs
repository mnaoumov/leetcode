
using JetBrains.Annotations;

namespace LeetCode._0417_Pacific_Atlantic_Water_Flow;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.PacificAtlantic(testCase.Heights), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Heights { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
