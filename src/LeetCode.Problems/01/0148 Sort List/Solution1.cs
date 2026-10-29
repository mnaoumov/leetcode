namespace LeetCode.Problems._0148_Sort_List;

/// <summary>
/// https://leetcode.com/problems/sort-list/submissions/845939126/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? SortList(ListNode? head)
    {
        if (head == null)
        {
            return null;
        }

        var mid = GetMiddleNode(head);

        if (mid.next == null)
        {
            return head;
        }

        var secondHalfHead = mid.next;
        mid.next = null;
        var sortedFirstListNode = SortList(head);
        var sortedSecondListNode = SortList(secondHalfHead);

        var mergeRoot = new ListNode();
        var mergeNodeParent = mergeRoot;

        while (sortedFirstListNode != null || sortedSecondListNode != null)
        {
            var firstVal = sortedFirstListNode?.val ?? int.MaxValue;
            var secondVal = sortedSecondListNode?.val ?? int.MaxValue;

            if (firstVal <= secondVal)
            {
                mergeNodeParent.next = sortedFirstListNode;
                sortedFirstListNode = sortedFirstListNode!.next;
            }
            else
            {
                mergeNodeParent.next = sortedSecondListNode;
                sortedSecondListNode = sortedSecondListNode!.next;
            }

            mergeNodeParent = mergeNodeParent.next!;
            mergeNodeParent.next = null;
        }

        return mergeRoot.next;
    }

    private static ListNode GetMiddleNode(ListNode head)
    {
        var middle = head;
        var tail = head.next;

        while (tail?.next != null)
        {
            middle = middle.next!;
            tail = tail.next.next;
        }

        return middle;
    }
}
