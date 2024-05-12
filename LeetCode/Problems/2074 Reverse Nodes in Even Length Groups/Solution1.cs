using JetBrains.Annotations;

namespace LeetCode.Problems._2074_Reverse_Nodes_in_Even_Length_Groups;

/// <summary>
/// https://leetcode.com/submissions/detail/899421071/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode ReverseEvenLengthGroups(ListNode head)
    {
        var fakeRoot = new ListNode(0, head);

        var beforeGroupNode = fakeRoot;
        var nextGroupLength = 1;

        while (beforeGroupNode.next != null)
        {
            var node = beforeGroupNode;
            var groupLength = 0;

            for (var i = 0; i < nextGroupLength; i++)
            {
                if (node.next == null)
                {
                    break;
                }

                node = node.next;
                groupLength++;
            }

            beforeGroupNode = (groupLength & 1) == 0 ? ReverseList(beforeGroupNode, node) : node;
            nextGroupLength++;
        }

        return fakeRoot.next!;
    }

    private static ListNode ReverseList(ListNode beforeStartNode, ListNode endNode)
    {
        var newEndNode = beforeStartNode.next!;
        var afterEndNode = endNode.next;

        var node = newEndNode;
        var next = afterEndNode;

        while (!ReferenceEquals(next, endNode))
        {
            var oldNext = node!.next;
            node.next = next;
            next = node;
            node = oldNext;
        }

        beforeStartNode.next = endNode;
        return newEndNode;
    }
}
