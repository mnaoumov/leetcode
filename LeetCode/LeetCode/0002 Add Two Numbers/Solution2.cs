namespace LeetCode._0002_Add_Two_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/147402105/
/// </summary>
public class Solution2 : ISolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode beforeFirstNode = new ListNode();
        ListNode lastResultDigitNode = beforeFirstNode;
        var memory = 0;

        ListNode? node1 = l1;
        ListNode? node2 = l2;

        while (node1 != null || node2 != null || memory != 0)
        {
            var sum = memory;
            if (node1 != null)
            {
                sum += node1.val;
                node1 = node1.next;
            }

            if (node2 != null)
            {
                sum += node2.val;
                node2 = node2.next;
            }

            if (sum >= 10)
            {
                memory = 1;
                sum -= 10;
            }
            else
            {
                memory = 0;
            }
            var currentResultDigitNode = new ListNode(sum);
            lastResultDigitNode.next = currentResultDigitNode;

            lastResultDigitNode = currentResultDigitNode;
        }

        if (beforeFirstNode.next == null)
        {
            return new ListNode();
        }

        return beforeFirstNode.next;
    }
}