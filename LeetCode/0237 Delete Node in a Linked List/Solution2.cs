namespace LeetCode._0237_Delete_Node_in_a_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/821254721/
/// </summary>
public class Solution2 : ISolution
{
    public void DeleteNode(ListNode node)
    {
        while (true)
        {
            node.val = node.next!.val;
            
            if (node.next.next == null)
            {
                node.next = null;
                break;
            }

            node = node.next;
        }
    }
}