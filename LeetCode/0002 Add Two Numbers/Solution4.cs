using JetBrains.Annotations;

namespace LeetCode._0002_Add_Two_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/817381289/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public ListNode AddTwoNumbers(ListNode? l1, ListNode? l2)
    {
        ListNode? result = null;
        var carry = false;
        var listNode = new ListNode();
        while (l1 != null || l2 != null || carry)
        {
            var value = (l1?.val ?? 0) + (l2?.val ?? 0);
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

            l1 = l1?.next;
            l2 = l2?.next;
        }

        return result!;
    }
}