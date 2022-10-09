#pragma warning disable CS8602
namespace LeetCode._0237_Delete_Node_in_a_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/193811710/
/// </summary>
public class Solution1 : ISolution
{
    public void DeleteNode(ListNode node)
    {
        while (node.next.next != null)
        {
            node.val = node.next.val;
            node = node.next;
        }

        node.val = node.next.val;
        node.next = null;
    }
}
