
using JetBrains.Annotations;

namespace LeetCode.Problems._1489_Find_Critical_and_Pseudo_Critical_Edges_in_Minimum_Spanning_Tree;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindCriticalAndPseudoCriticalEdges(testCase.N, testCase.Edges), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public IList<IList<int>> Output { get; [UsedImplicitly] init; } = null!;
    }
}
