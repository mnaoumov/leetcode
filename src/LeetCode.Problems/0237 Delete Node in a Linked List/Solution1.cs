#pragma warning disable


// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0237_Delete_Node_in_a_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/193811710/
/// </summary>
[UsedImplicitly]
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
