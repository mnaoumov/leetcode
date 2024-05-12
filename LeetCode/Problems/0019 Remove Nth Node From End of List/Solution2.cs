#pragma warning disable
using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0019_Remove_Nth_Node_From_End_of_List;

/// <summary>
/// https://leetcode.com/submissions/detail/810070816/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var beforeHeadFakeNode = new ListNode(0, head);

        var node = head;

        for (int i = 0; i < n; i++)
        {
            node = node.next;
        }

        var nodeBeforeNthFromEnd = beforeHeadFakeNode;

        while (node != null)
        {
            node = node.next;
            nodeBeforeNthFromEnd = nodeBeforeNthFromEnd.next;
        }

        nodeBeforeNthFromEnd.next = nodeBeforeNthFromEnd.next.next;

        return beforeHeadFakeNode.next;
    }
}
