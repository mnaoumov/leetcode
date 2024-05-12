using JetBrains.Annotations;

namespace LeetCode._0083_Remove_Duplicates_from_Sorted_List;

/// <summary>
/// https://leetcode.com/submissions/detail/822541644/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? DeleteDuplicates(ListNode? head)
    {
        var parent = head;
        var node = head?.next;

        while (node != null)
        {
            if (node.val == parent!.val)
            {
                parent.next = node.next;
            }
            else
            {
                parent = node;
            }

            node = node.next;
        }

        return head;
    }
}
