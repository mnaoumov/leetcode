using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0445_Add_Two_Numbers_II;

/// <summary>
/// https://leetcode.com/submissions/detail/951007276/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var length1 = Length(l1);
        var length2 = Length(l2);

        if (length1 < length2)
        {
            (length1, length2) = (length2, length1);
            (l1, l2) = (l2, l1);
        }

        ListNode? reverseSumNode = null;
        var node1 = l1;
        var node2 = l2;

        for (var i = length1; i > length2; i--)
        {
            reverseSumNode = new ListNode(node1.val, reverseSumNode);
            node1 = node1.next!;
        }

        while (node1 != null)
        {
            reverseSumNode = new ListNode(node1.val + node2!.val, reverseSumNode);
            node1 = node1.next;
            node2 = node2.next;
        }

        ListNode? sumNode = null;
        var carry = false;

        while (reverseSumNode != null)
        {
            var value = reverseSumNode.val + (carry ? 1 : 0);
            carry = value >= 10;
            sumNode = new ListNode(carry ? value - 10 : value, sumNode);
            reverseSumNode = reverseSumNode.next;
        }

        if (carry)
        {
            sumNode = new ListNode(1, sumNode);
        }

        return sumNode!;
    }

    private static int Length(ListNode node)
    {
        var ans = 0;
        var node2 = node;
        while (node2 != null)
        {
            ans++;
            node2 = node2.next;
        }

        return ans;
    }
}
