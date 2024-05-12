using JetBrains.Annotations;

namespace LeetCode._2130_Maximum_Twin_Sum_of_a_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/857317831/w
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PairSum(ListNode head)
    {
        var slow = head;
        var fast = head;

        while (fast != null)
        {
            slow = slow!.next;
            fast = fast.next!.next;
        }

        var node = slow;
        ListNode? tail = null;

        while (node != null)
        {
            var next = node.next;
            node.next = tail;
            tail = node;
            node = next;
        }

        var firstHalfListNode = head;
        var secondHalfListReversedNode = tail;

        var result = int.MinValue;

        while (secondHalfListReversedNode != null)
        {
            result = Math.Max(result, firstHalfListNode!.val + secondHalfListReversedNode.val);
            firstHalfListNode = firstHalfListNode.next;
            secondHalfListReversedNode = secondHalfListReversedNode.next;
        }

        return result;
    }
}
