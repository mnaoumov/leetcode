using JetBrains.Annotations;

namespace LeetCode.Problems._0369_Plus_One_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/946352974/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode PlusOne(ListNode head)
    {
        var node = head;

        ListNode? lastNotNineNode = null;
        var ans = head;

        while (node != null)
        {
            if (node.val != 9)
            {
                lastNotNineNode = node;
            }

            node = node.next;
        }

        if (lastNotNineNode == null)
        {
            ans = new ListNode(0, head);
            lastNotNineNode = ans;
        }

        lastNotNineNode.val++;
        node = lastNotNineNode.next;

        while (node != null)
        {
            node.val = 0;
            node = node.next;
        }

        return ans;
    }
}
