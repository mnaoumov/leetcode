using JetBrains.Annotations;
using NUnit.Framework;

namespace LeetCode.Problems._0092_Reverse_Linked_List_II;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        Assert.That(solution.ReverseBetween(ListNode.Create(testCase.Values), testCase.Left, testCase.Right), Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int Left { get; [UsedImplicitly] init; }
        public int Right { get; [UsedImplicitly] init; }
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
    }
}
