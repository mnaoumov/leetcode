using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0061_Rotate_List;

/// <summary>
/// https://leetcode.com/submissions/detail/819499147/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode RotateRight(ListNode head, int k)
    {
        var count = 0;
        var node = head;
        while (node != null)
        {
            node = node.next;
            count++;
        }

        if (count == 0)
        {
            return head;
        }

        k = k % count;

        if (k == 0)
        {
            return head;
        }

        var fakeRoot = new ListNode { next = head };

        node = head;
        var newHeadParent = fakeRoot;
        ListNode oldTail = null!;

        for (var i = 0; i < k; i++)
        {
            node = node!.next;
        }

        while (node != null)
        {
            oldTail = node;
            node = node.next;
            newHeadParent = newHeadParent!.next;
        }

        var newHead = newHeadParent!.next!;
        newHeadParent.next = null;
        oldTail.next = head;
        return newHead;
    }
}