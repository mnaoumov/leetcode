namespace LeetCode.Problems._0206_Reverse_Linked_List;

/// <seealso href="https://leetcode.com/submissions/detail/923166578/"/>
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
