using JetBrains.Annotations;

namespace LeetCode.Problems._0725_Split_Linked_List_in_Parts;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var output = testCase.Output.Select(ListNode.CreateOrNull);
        AssertCollectionEqualWithDetails(solution.SplitListToParts(ListNode.CreateOrNull(testCase.Head), testCase.K),
            output);
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int K { get; [UsedImplicitly] init; }
        public int[][] Output { get; [UsedImplicitly] init; } = null!;
    }
}
