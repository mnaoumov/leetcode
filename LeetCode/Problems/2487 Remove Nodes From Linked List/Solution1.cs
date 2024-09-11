namespace LeetCode.Problems._2487_Remove_Nodes_From_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/850807006/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode RemoveNodes(ListNode head)
    {
        var stack = new Stack<ListNode>();

        var node = head;

        while (node != null)
        {
            while (stack.TryPeek(out var lastMinNode) && lastMinNode.val < node.val)
            {
                stack.Pop();
            }

            stack.Push(node);
            node = node.next;
        }

        ListNode? next = null;

        while (stack.Count > 0)
        {
            node = stack.Pop();
            node.next = next;
            next = node;
        }

        return next!;
    }
}
