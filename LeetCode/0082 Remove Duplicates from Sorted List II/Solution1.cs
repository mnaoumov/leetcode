#pragma warning disable
using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0082_Remove_Duplicates_from_Sorted_List_II;

/// <summary>
/// https://leetcode.com/submissions/detail/822535370/
/// </summary>
[SkipSolution(SkipSolutionReason.RuntimeError)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode DeleteDuplicates(ListNode head)
    {
        var fakeRoot = new ListNode(0, head);

        var node = head.next;
        var parent = head;
        var grandparent = fakeRoot;
        var lastValue = head.val;

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

            lastValue = parent?.val ?? 0;
            node = parent?.next;
        }

        return fakeRoot.next!;
    }
}