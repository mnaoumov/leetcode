namespace LeetCode._0082_Remove_Duplicates_from_Sorted_List_II;

/// <summary>
/// https://leetcode.com/submissions/detail/822537206/
/// </summary>
public class Solution2 : ISolution
{
    public ListNode? DeleteDuplicates(ListNode? head)
    {
        var fakeRoot = new ListNode(0, head);

        var node = head?.next;
        var parent = head;
        var grandparent = fakeRoot;
        var lastValue = head?.val;

        while (node != null)
        {
            if (node.val == lastValue)
            {
                while (parent?.val == lastValue)
                {
                    parent = parent.next;
                }
                grandparent.next = parent;
            }
            else
            {
                grandparent = parent!;
                parent = node;
            }

            lastValue = parent?.val;
            node = parent?.next;
        }

        return fakeRoot.next;
    }
}