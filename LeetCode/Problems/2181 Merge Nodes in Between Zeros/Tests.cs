using JetBrains.Annotations;

namespace LeetCode.Problems._2181_Merge_Nodes_in_Between_Zeros;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        AssertCollectionEqualWithDetails(solution.MergeNodes(ListNode.CreateOrNull(testCase.Head)), ListNode.CreateOrNull(testCase.Output));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
