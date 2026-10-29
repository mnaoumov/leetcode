namespace LeetCode.Problems._1836_Remove_Duplicates_From_an_Unsorted_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/1313415100/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? DeleteDuplicatesUnsorted(ListNode head)
    {
        var values = new HashSet<int>();
        var duplicates = new HashSet<int>();

        for (var node = head; node != null; node = node.next)
        {
            if (!values.Add(node.val))
            {
                duplicates.Add(node.val);
            }
        }

        var ansParent = new ListNode();

        var ansNode = ansParent;

        for (var node = head; node != null; node = node.next)
        {
            if (duplicates.Contains(node.val))
            {
                continue;
            }

            ansNode.next = new ListNode(node.val);
            ansNode = ansNode.next;
        }

        return ansParent.next;
    }
}
