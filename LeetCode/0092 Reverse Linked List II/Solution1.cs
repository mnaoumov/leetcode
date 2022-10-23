using JetBrains.Annotations;

namespace LeetCode._0092_Reverse_Linked_List_II;

/// <summary>
/// https://leetcode.com/submissions/detail/828898795/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode ReverseBetween(ListNode head, int left, int right)
    {
        var fakeRoot = new ListNode(0, head);

        var beforeLeftNode = fakeRoot;

        for (var i = 0; i < left - 1; i++)
        {
            beforeLeftNode = beforeLeftNode.next!;
        }

        var leftNode = beforeLeftNode.next!;
        var reversedNode = leftNode;

        for (var i = left + 1; i <= right; i++)
        {
            var node = leftNode.next!;
            leftNode.next = node.next;
            node.next = reversedNode;
            reversedNode = node;
        }

        beforeLeftNode.next = reversedNode;

        return fakeRoot.next!;
    }
}