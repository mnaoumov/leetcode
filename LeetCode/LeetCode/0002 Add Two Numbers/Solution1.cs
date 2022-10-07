namespace LeetCode._0002_Add_Two_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/147401756/
/// </summary>
public class Solution1 : ISolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode? firstResultDigitNode = null;
        ListNode? lastResultDigitNode = null;
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

            memory = sum / 10;
            var currentResultDigitNode = new ListNode(sum % 10);
            if (lastResultDigitNode != null)
            {
                lastResultDigitNode.next = currentResultDigitNode;
            }
            else
            {
                firstResultDigitNode = currentResultDigitNode;
            }

            lastResultDigitNode = currentResultDigitNode;
        }

        if (firstResultDigitNode == null)
        {
            return new ListNode();
        }

        return firstResultDigitNode;
    }
}