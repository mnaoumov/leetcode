namespace LeetCode.Problems._1474_Delete_N_Nodes_After_M_Nodes_of_a_Linked_List;

/// <summary>
/// https://leetcode.com/problems/delete-n-nodes-after-m-nodes-of-a-linked-list/submissions/1647605481/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode DeleteNodes(ListNode head, int m, int n)
    {
        var node = head;
        var parent = head;

        while (true)
        {
            for (var i = 0; i < m; i++)
            {
                if (node == null)
                {
                    break;
                }

                parent = node;
                node = node.next;
            }

            if (node == null)
            {
                break;
            }

            for (var i = 0; i < n; i++)
            {
                if (node == null)
                {
                    break;
                }
                node = node.next;
            }

            parent.next = node;
        }

        return head;
    }
}
