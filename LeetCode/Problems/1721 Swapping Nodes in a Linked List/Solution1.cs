using JetBrains.Annotations;

namespace LeetCode.Problems._1721_Swapping_Nodes_in_a_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/899040016/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode SwapNodes(ListNode head, int k)
    {
        var slow = head;
        var fast = head;

        for (var i = 1; i < k; i++)
        {
            fast = fast.next!;
        }

        var kFromBeginning = fast;

        while (fast.next != null)
        {
            fast = fast.next;
            slow = slow.next!;
        }

        var kFromEnd = slow;

        (kFromBeginning.val, kFromEnd.val) = (kFromEnd.val, kFromBeginning.val);

        return head;
    }
}
