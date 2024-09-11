using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3112_Minimum_Time_to_Visit_Disappearing_Nodes;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MinimumTime(testCase.N, testCase.Edges, testCase.Disappear), testCase.Output);
    }

    public class TestCase : TestCaseBase
    {
        public int N { get; [UsedImplicitly] init; }
        public int[][] Edges { get; [UsedImplicitly] init; } = null!;
        public int[] Disappear { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
