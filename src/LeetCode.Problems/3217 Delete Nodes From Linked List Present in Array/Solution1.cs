namespace LeetCode.Problems._3217_Delete_Nodes_From_Linked_List_Present_in_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1380577251/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? ModifiedList(int[] nums, ListNode head)
    {
        var set = nums.ToHashSet();

        var ansParent = new ListNode();
        var ansNode = ansParent;

        for (var node = head; node != null; node = node.next)
        {
            if (set.Contains(node.val))
            {
                continue;
            }

            ansNode.next = new ListNode(node.val);
            ansNode = ansNode.next;
        }

        return ansParent.next;
    }
}
