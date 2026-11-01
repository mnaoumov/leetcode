namespace LeetCode.Problems._0203_Remove_Linked_List_Elements;

/// <seealso href="https://leetcode.com/submissions/detail/899425157/">Submission</seealso>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? RemoveElements(ListNode? head, int val)
    {
        var fakeRoot = new ListNode(0, head);
        var node = fakeRoot;

        while (node.next != null)
        {
            var next = node.next;

            if (next.val == val)
            {
                node.next = next.next;
            }
            else
            {
                node = next;
            }
        }

        return fakeRoot.next;
    }
}
