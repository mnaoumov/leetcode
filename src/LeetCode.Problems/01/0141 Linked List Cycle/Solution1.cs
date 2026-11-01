namespace LeetCode.Problems._0141_Linked_List_Cycle;

/// <seealso href="https://leetcode.com/problems/linked-list-cycle/submissions/841555534/">Submission</seealso>
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
