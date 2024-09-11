using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0206_Reverse_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/923169183/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode? ReverseList(ListNode? head)
    {
        if (head == null)
        {
            return null;
        }

        if (head.next == null)
        {
            return head;
        }

        var result = ReverseList(head.next)!;

        var node = result;

        while (node.next != null)
        {
            node = node.next;
        }

        node.next = new ListNode(head.val);

        return result;
    }
}
