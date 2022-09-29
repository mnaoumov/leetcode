namespace LeetCode._024_Swap_Nodes_in_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/811116954/
/// </summary>
public class Solution : ISolution
{
    public ListNode? SwapPairs(ListNode? head)
    {
        var fakeBeforeHeadNode = new ListNode(0, head);

        var beforePairNode = fakeBeforeHeadNode;

        while (true)
        {
            var firstInPairNode = beforePairNode.next;
            
            if (firstInPairNode == null)
            {
                break;
            }

            var secondInPairNode = firstInPairNode.next;
            if (secondInPairNode == null)
            {
                break;
            }

            var afterPairNode = secondInPairNode.next;

            beforePairNode.next = secondInPairNode;
            secondInPairNode.next = firstInPairNode;
            firstInPairNode.next = afterPairNode;

            beforePairNode = firstInPairNode;
        }

        return fakeBeforeHeadNode.next;
    }
}