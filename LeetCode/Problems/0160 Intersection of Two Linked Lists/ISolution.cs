using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0160_Intersection_of_Two_Linked_Lists;

[PublicAPI]
public interface ISolution
{
    public ListNode? GetIntersectionNode(ListNode headA, ListNode headB);
}
