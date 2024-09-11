using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0160_Intersection_of_Two_Linked_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/870054700/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ListNode? GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var nodeA = headA;
        var nodeB = headB;

        const int bigValue = 1_000_000;

        while (nodeA != null && nodeB != null && nodeA.val < bigValue && nodeB.val < bigValue)
        {
            nodeA.val += bigValue;

            if (nodeB.val >= bigValue)
            {
                break;
            }

            nodeB.val += bigValue;
            nodeA = nodeA.next;
            nodeB = nodeB.next;
        }

        ListNode? result = null;
        if (nodeA is { val: >= bigValue })
        {
            result = nodeA;
        }
        else if (nodeB is { val: >= bigValue })
        {
            result = nodeB;
        }

        nodeA = headA;

        while (nodeA is { val: >= bigValue })
        {
            nodeA.val -= bigValue;
            nodeA = nodeA.next;
        }

        nodeB = headB;

        while (nodeB is { val: >= bigValue })
        {
            nodeB.val -= bigValue;
            nodeB = nodeB.next;
        }

        return result;
    }
}
