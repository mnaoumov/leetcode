using JetBrains.Annotations;

namespace LeetCode._0160_Intersection_of_Two_Linked_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/870060301/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ListNode? GetIntersectionNode(ListNode headA, ListNode headB)
    {
        var lengthA = Length(headA);
        var lengthB = Length(headB);

        if (lengthA < lengthB)
        {
            (headA, headB, lengthA, lengthB) = (headB, headA, lengthB, lengthA);
        }

        var nodeA = headA;
        var nodeB = headB;

        for (var i = 0; i < lengthA - lengthB; i++)
        {
            nodeA = nodeA!.next;
        }

        for (var i = 0; i < lengthB; i++)
        {
            if (ReferenceEquals(nodeA, nodeB))
            {
                return nodeA;
            }

            nodeA = nodeA!.next;
            nodeB = nodeB!.next;
        }

        return null;
    }

    private static int Length(ListNode list)
    {
        var node = list;
        var result = 0;

        while (node != null)
        {
            node = node.next;
            result++;
        }

        return result;
    }
}
