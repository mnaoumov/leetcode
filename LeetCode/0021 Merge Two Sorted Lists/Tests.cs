using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0021_Merge_Two_Sorted_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.MergeTwoLists(ListNode.Create(testCase.List1Values), ListNode.Create(testCase.List2Values)), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] List1Values { get; [UsedImplicitly] init; } = null!;
        public int[] List2Values { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}