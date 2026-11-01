namespace LeetCode.Problems._0876_Middle_of_the_Linked_List;

/// <seealso href="https://leetcode.com/problems/middle-of-the-linked-list/submissions/845896212/">Submission</seealso>
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
