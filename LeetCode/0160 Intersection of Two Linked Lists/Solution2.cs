using JetBrains.Annotations;

namespace LeetCode._0160_Intersection_of_Two_Linked_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/870057499/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode? GetIntersectionNode(ListNode headA, ListNode headB)
    {
        const int bigValue = 1_000_000;

        var nodeA = headA;

        while (nodeA != null)
        {
            nodeA.val += bigValue;
            nodeA = nodeA.next;
        }

        var nodeB = headB;

        while (nodeB is { val: < bigValue })
        {
            nodeB = nodeB.next;
        }

        nodeA = headA;

        while (nodeA != null)
        {
            nodeA.val -= bigValue;
            nodeA = nodeA.next;
        }

        return nodeB;
    }
}
