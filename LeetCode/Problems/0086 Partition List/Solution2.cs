using JetBrains.Annotations;

namespace LeetCode.Problems._0086_Partition_List;

/// <summary>
/// https://leetcode.com/submissions/detail/827457342/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode Partition(ListNode head, int x)
    {
        var fakeRoot = new ListNode(0, head);

        ListNode? partitionStartParentNode = null;

        var parentNode = fakeRoot;

        while (parentNode.next != null)
        {
            var node = parentNode.next;
            if (node.val >= x)
            {
                partitionStartParentNode ??= parentNode;
                parentNode = parentNode.next!;
            }
            else if (partitionStartParentNode != null)
            {
                var partitionStartNode = partitionStartParentNode.next;
                parentNode.next = node.next;

                partitionStartParentNode.next = node;
                partitionStartParentNode = node;

                node.next = partitionStartNode;
            }
            else
            {
                parentNode = parentNode.next!;
            }
        }

        return fakeRoot.next!;
    }
}
