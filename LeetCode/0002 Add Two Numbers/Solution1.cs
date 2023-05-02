// ReSharper disable All
#pragma warning disable
using JetBrains.Annotations;

namespace LeetCode._0002_Add_Two_Numbers;

/// <summary>
/// https://leetcode.com/submissions/detail/147401756/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode firstResultDigitNode = null;
        ListNode lastResultDigitNode = null;
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
            return new ListNode(0);
        }

        return firstResultDigitNode;
    }
}
