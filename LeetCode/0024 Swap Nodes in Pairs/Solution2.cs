using JetBrains.Annotations;

namespace LeetCode._0024_Swap_Nodes_in_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/829012598/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode? SwapPairs(ListNode? head)
    {
        var fakeBeforeHeadNode = new ListNode(0, head);

        var beforePairNode = fakeBeforeHeadNode;

        while (true)
        {
            var firstInPairNode = beforePairNode.next;

            var secondInPairNode = firstInPairNode?.next;
            if (secondInPairNode == null)
            {
                break;
            }

            var afterPairNode = secondInPairNode.next;

            beforePairNode.next = secondInPairNode;
            secondInPairNode.next = firstInPairNode;
            firstInPairNode!.next = afterPairNode;

            beforePairNode = firstInPairNode;
        }

        return fakeBeforeHeadNode.next;
    }
}