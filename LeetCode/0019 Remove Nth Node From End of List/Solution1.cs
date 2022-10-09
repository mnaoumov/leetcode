// ReSharper disable All
#pragma warning disable CS8602
#pragma warning disable CS8603
#pragma warning disable CS8625
namespace LeetCode._0019_Remove_Nth_Node_From_End_of_List;

/// <summary>
/// https://leetcode.com/submissions/detail/198154527/
/// </summary>
public class Solution1 : ISolution
{
    public ListNode RemoveNthFromEnd(ListNode head, int n)
    {
        var queue = new Queue<ListNode>(n + 1);

        for (int i = 0; i < n + 1; i++)
        {
            queue.Enqueue(null);
        }

        var node = head;
        while (node != null)
        {
            queue.Dequeue();
            queue.Enqueue(node);
            node = node.next;
        }

        var previous = queue.Dequeue();
        if (previous == null)
        {
            return head.next;
        }

        previous.next = previous.next.next;

        return head;
    }
}