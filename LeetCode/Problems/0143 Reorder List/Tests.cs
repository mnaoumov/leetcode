namespace LeetCode.Problems._0143_Reorder_List;

[UsedImplicitly]
public class Tests : TestsBase<ISolution, Tests.TestCase>
{
    protected override void TestImpl(ISolution solution, TestCase testCase)
    {
        var head = ListNode.Create(testCase.Head);

        var map = new Dictionary<int, ListNode>();

        var node = head;

        while (node != null)
        {
            map[node.val] = node;
            node = node.next;
        }

        solution.ReorderList(head);

        Assert.That(head, Is.EqualTo(ListNode.Create(testCase.Output)));

        node = head;

        while (node != null)
        {
            Assert.That(map[node.val], Is.SameAs(node));
            node = node.next;
        }
    }

    public class TestCase : TestCaseBase
    {
        public int[] Head { get; [UsedImplicitly] init; } = null!;
        public int[] Output { get; [UsedImplicitly] init; } = null!;
    }
}
