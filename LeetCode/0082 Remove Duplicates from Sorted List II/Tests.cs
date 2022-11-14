using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0082_Remove_Duplicates_from_Sorted_List_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.DeleteDuplicates(ListNode.CreateOrNull(testCase.Values)), Is.EqualTo(ListNode.CreateOrNull(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase<TestCase>
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}