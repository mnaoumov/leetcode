// ReSharper disable All
#pragma warning disable
#pragma warning disable
using JetBrains.Annotations;

namespace LeetCode._0002_Add_Two_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/147402105/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode beforeFirstNode = new ListNode(0);
        ListNode lastResultDigitNode = beforeFirstNode;
        var memory = 0;

        while (l1 != null || l2 != null || memory != 0)
        {
            var sum = memory;
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
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
            return new ListNode(0);
        }

        return beforeFirstNode.next;
    }
}
