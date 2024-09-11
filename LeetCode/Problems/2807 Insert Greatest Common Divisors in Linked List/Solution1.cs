using System.Numerics;
using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2807_Insert_Greatest_Common_Divisors_in_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/1384838267/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode InsertGreatestCommonDivisors(ListNode head)
    {
        var ans = new ListNode(head.val);
        var node = head.next;
        var ansNode = ans;

        while (node != null)
        {
            var previousValue = ansNode.val;
            var currentValue = node.val;
            var gcd = (int) BigInteger.GreatestCommonDivisor(previousValue, currentValue);
            ansNode.next = new ListNode(gcd);
            ansNode = ansNode.next;
            ansNode.next = new ListNode(currentValue);
            ansNode = ansNode.next;

            node = node.next;
        }

        return ans;
    }
}
