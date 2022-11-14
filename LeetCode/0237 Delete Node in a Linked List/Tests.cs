using NUnit.Framework;

using JetBrains.Annotations;

namespace LeetCode._0237_Delete_Node_in_a_Linked_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var root = ListNode.Create(testCase.Values);
        var node = root.FindNode(testCase.NodeValue)!;
        solution.DeleteNode(node);
        Assert.That(root, Is.EqualTo(ListNode.Create(testCase.OutputValues)));
    }

    public class TestCase : TestCaseBase
    {
        public int[] Values { get; [UsedImplicitly] init; } = null!;
        public int[] OutputValues { get; [UsedImplicitly] init; } = null!;
        public int NodeValue { get; [UsedImplicitly] init; }
    }
}