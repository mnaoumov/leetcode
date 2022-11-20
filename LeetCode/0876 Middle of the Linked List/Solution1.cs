using JetBrains.Annotations;

namespace LeetCode._0876_Middle_of_the_Linked_List;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode MiddleNode(ListNode head)
    {
        var middle = head;
        var end = head;

        while (end?.next != null)
        {
            middle = middle.next!;
            end = end.next.next;
        }

        return middle;
    }
}
