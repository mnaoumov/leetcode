
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0587_Erect_the_Fence;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEquivalentWithDetails(solution.OuterTrees(testCase.Trees), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int[][] Trees { get; [UsedImplicitly] init; } = null!;
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
