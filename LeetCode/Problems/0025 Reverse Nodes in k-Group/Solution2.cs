using JetBrains.Annotations;

namespace LeetCode.Problems._0025_Reverse_Nodes_in_k_Group;

/// <summary>
/// https://leetcode.com/submissions/detail/829013137/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ListNode ReverseKGroup(ListNode head, int k)
    {
        var fakeRoot = new ListNode(0, head);

        var beforeGroupNode = fakeRoot;

        while (true)
        {
            var afterGroupNode = beforeGroupNode;

            for (var i = 0; i < k + 1; i++)
            {
                if (afterGroupNode == null)
                {
                    return fakeRoot.next!;
                }

                afterGroupNode = afterGroupNode.next;
            }

            var node = beforeGroupNode!.next;
            var newNext = afterGroupNode;
            ListNode? newBeforeGroupNode = null;

            for (var i = 0; i < k; i++)
            {
                var oldNext = node!.next;
                node.next = newNext;

                if (i == 0)
                {
                    newBeforeGroupNode = node;
                }

                newNext = node;
                node = oldNext;
            }

            beforeGroupNode.next = newNext;
            beforeGroupNode = newBeforeGroupNode;
        }
    }
}
