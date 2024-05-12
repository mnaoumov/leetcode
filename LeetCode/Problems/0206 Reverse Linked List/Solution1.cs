using JetBrains.Annotations;

namespace LeetCode.Problems._0206_Reverse_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/923166578/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? ReverseList(ListNode? head)
    {
        ListNode? result = null;
        var node = head;

        while (node != null)
        {
            result = new ListNode(node.val, result);
            node = node.next;
        }

        return result;
    }
}
