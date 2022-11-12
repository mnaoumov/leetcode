using JetBrains.Annotations;

namespace LeetCode._0141_Linked_List_Cycle;

/// <summary>
/// https://leetcode.com/problems/linked-list-cycle/submissions/841555534/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasCycle(ListNode head)
    {
        var slowNode = head;
        var fastNode = head;

        while (slowNode != null && fastNode?.next != null)
        {
            slowNode = slowNode.next;
            fastNode = fastNode.next.next;

            if (ReferenceEquals(slowNode, fastNode))
            {
                return true;
            }
        }

        return false;
    }
}
