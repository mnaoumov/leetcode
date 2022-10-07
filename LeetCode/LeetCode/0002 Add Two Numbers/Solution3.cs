namespace LeetCode._0002_Add_Two_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/805526963/
/// </summary>
public class Solution3 : ISolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode result = null!;
        var carry = false;
        var listNode = new ListNode();

        ListNode? node1 = l1;
        ListNode? node2 = l2;

        while (node1 != null || node2 != null || carry)
        {
            var value = (node1?.val ?? 0) + (node2?.val ?? 0);
            if (carry)
            {
                value += 1;
            }

            carry = value >= 10;

            if (carry)
            {
                value -= 10;
            }

            listNode.next = new ListNode(value);
            listNode = listNode.next;

            result ??= listNode;

            node1 = node1?.next;
            node2 = node2?.next;
        }

        return result!;
    }
}