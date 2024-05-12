using JetBrains.Annotations;

namespace LeetCode.Problems._0147_Insertion_Sort_List;

/// <summary>
/// https://leetcode.com/problems/insertion-sort-list/submissions/845928304/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode InsertionSortList(ListNode head)
    {
        var fakeRoot = new ListNode(0, head);

        var sortedTail = fakeRoot;
        while (sortedTail.next != null)
        {
            var node = sortedTail.next;
            var beforeInserted = fakeRoot;

            while (!Equals(beforeInserted, sortedTail))
            {
                if (beforeInserted.next!.val > node.val)
                {
                    break;
                }

                beforeInserted = beforeInserted.next;
            }

            if (Equals(beforeInserted, sortedTail))
            {
                (beforeInserted.next, sortedTail) = (node, node);
            }
            else
            {
                (beforeInserted.next, node.next, sortedTail.next) = (node, beforeInserted.next, node.next);
            }
        }

        return fakeRoot.next!;
    }
}
