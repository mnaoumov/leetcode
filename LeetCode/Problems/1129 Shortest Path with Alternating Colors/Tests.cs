
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1129_Shortest_Path_with_Alternating_Colors;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.ShortestAlternatingPaths(testCase.N, testCase.RedEdges, testCase.BlueEdges), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] RedEdges { get; [UsedImplicitly] init; } = null!;
        public int[][] BlueEdges { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
