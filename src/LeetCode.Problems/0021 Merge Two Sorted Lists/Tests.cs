namespace LeetCode.Problems._0021_Merge_Two_Sorted_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestCore(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MergeTwoLists(ListNode.CreateOrNull(testCase.List1Values), ListNode.CreateOrNull(testCase.List2Values)), Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] List1Values { get; [UsedImplicitly] init; } = null!;
        public int[] List2Values { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}
