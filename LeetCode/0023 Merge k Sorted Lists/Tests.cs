using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0023_Merge_k_Sorted_Lists;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var lists = testCase.ListValuesArr.Select(ListNode.CreateOrNull).ToArray();

        Assert.That(solution.MergeKLists(lists), Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[][] ListValuesArr { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}