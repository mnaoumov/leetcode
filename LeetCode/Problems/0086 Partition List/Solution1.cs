using JetBrains.Annotations;
using LeetCode.Base;
using LeetCode.DataStructure;

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0086_Partition_List;

/// <summary>
/// https://leetcode.com/submissions/detail/827454880/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public ListNode Partition(ListNode head, int x)
    {
        var fakeRoot = new ListNode(0, head);

        ListNode? partitionStartParentNode = null;

        var parentNode = fakeRoot;

        while (parentNode?.next != null)
        {
            var node = parentNode.next;
            if (node.val >= x)
            {
                partitionStartParentNode ??= parentNode;
            }
            else if (partitionStartParentNode != null)
            {
                var partitionStartNode = partitionStartParentNode.next;
                parentNode.next = node.next;

                partitionStartParentNode.next = node;
                partitionStartParentNode = node;

                node.next = partitionStartNode;
            }

            parentNode = parentNode.next!;
        }

        return fakeRoot.next!;
    }
}
