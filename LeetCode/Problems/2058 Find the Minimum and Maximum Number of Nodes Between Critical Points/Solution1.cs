using JetBrains.Annotations;

namespace LeetCode.Problems._2058_Find_the_Minimum_and_Maximum_Number_of_Nodes_Between_Critical_Points;

/// <summary>
/// https://leetcode.com/submissions/detail/1309980902/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] NodesBetweenCriticalPoints(ListNode head)
    {
        const int notFound = -1;
        var firstCriticalPointIndex = notFound;
        var lastCriticalPointIndex = notFound;
        var minDistance = int.MaxValue;

        var index = 1;
        var node = head;

        while (node?.next?.next != null)
        {
            var next = node.next!;
            var next2 = next.next!;

            if (next.val < node.val && next.val < next2.val || next.val > node.val && next.val > next2.val)
            {
                if (firstCriticalPointIndex == notFound)
                {
                    firstCriticalPointIndex = index;
                }

                if (lastCriticalPointIndex != notFound)
                {
                    minDistance = Math.Min(minDistance, index - lastCriticalPointIndex);
                }

                lastCriticalPointIndex = index;
            }

            node = node.next;
            index++;
        }

        return minDistance == int.MaxValue
            ? new[] { notFound, notFound }
            : new[] { minDistance, lastCriticalPointIndex - firstCriticalPointIndex };
    }
}
