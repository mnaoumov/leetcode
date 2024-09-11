using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1171_Remove_Zero_Sum_Consecutive_Nodes_from_Linked_List;

/// <summary>
/// https://leetcode.com/submissions/detail/1201076579/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? RemoveZeroSumSublists(ListNode head)
    {
        var sumToIndexMap = new Dictionary<int, int> { [0] = -1 };
        var sums = new List<int>();
        var ansIndices = new List<int>();
        var sum = 0;

        var ansIndex = 0;

        for (var node = head; node != null; node = node.next)
        {
            sum += node.val;

            if (sumToIndexMap.TryGetValue(sum, out var previousIndex))
            {
                for (var index = previousIndex + 1; index < ansIndices.Count; index++)
                {
                    sumToIndexMap.Remove(sums[index]);
                }

                sums.RemoveRange(previousIndex + 1, ansIndices.Count - previousIndex - 1);
                ansIndices.RemoveRange(previousIndex + 1, ansIndices.Count - previousIndex - 1);
            }
            else
            {
                sumToIndexMap[sum] = sums.Count;
                sums.Add(sum);
                ansIndices.Add(ansIndex);
            }

            ansIndex++;
        }

        var ansParent = new ListNode();
        var ansNode = ansParent;

        ansIndex = 0;

        var ansIndicesSet = ansIndices.ToHashSet();

        for (var node = head; node != null; node = node.next)
        {
            if (ansIndicesSet.Contains(ansIndex))
            {
                ansNode.next = new ListNode(node.val);
                ansNode = ansNode.next;
            }

            ansIndex++;
        }

        return ansParent.next;
    }
}
