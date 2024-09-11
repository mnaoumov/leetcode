using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3123_Find_Edges_in_Shortest_Paths;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.FindAnswer(testCase.N, testCase.Edges), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public bool[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
