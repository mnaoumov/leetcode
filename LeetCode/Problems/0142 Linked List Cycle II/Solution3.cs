using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0142_Linked_List_Cycle_II;

/// <summary>
/// https://leetcode.com/problems/linked-list-cycle-ii/submissions/841671301/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ListNode? DetectCycle(ListNode? head)
    {
        if (head == null)
        {
            return null;
        }

        var slowNode = head;
        var fastNode = head;

        while (true)
        {
            slowNode = slowNode.next!;
            fastNode = fastNode.next?.next;

            if (fastNode == null)
            {
                return null;
            }

            if (ReferenceEquals(slowNode, fastNode))
            {
                break;
            }
        }

        var resultNode = head;

        while (!ReferenceEquals(resultNode, slowNode))
        {
            resultNode = resultNode!.next;
            slowNode = slowNode!.next;
        }

        return resultNode;
    }
}
