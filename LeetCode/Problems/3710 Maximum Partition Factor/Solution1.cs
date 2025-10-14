namespace LeetCode.Problems._3710_Maximum_Partition_Factor;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-167/problems/maximum-partition-factor/submissions/1798446342/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxPartitionFactor(int[][] points)
    {
        if (points.Length == 2)
        {
            return 0;
        }

        var low = 0;
        var high = int.MaxValue;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            if (CanPartition(points, mid))
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return high;
    }

    private static bool CanPartition(int[][] points, int factor)
    {
        var group1 = new List<int[]>();
        var group2 = new List<int[]>();

        foreach (var point in points)
        {
            var minGroup = group1.Count <= group2.Count ? group1 : group2;
            var maxGroup = group1.Count <= group2.Count ? group2 : group1;
            var canGoToMinGroup = minGroup.All(groupPoint => ManhattanDistance(point, groupPoint) >= factor);

            if (canGoToMinGroup)
            {
                minGroup.Add(point);
                continue;
            }

            var canGoToMaxGroup = maxGroup.All(groupPoint => ManhattanDistance(point, groupPoint) >= factor);

            if (!canGoToMaxGroup)
            {
                return false;
            }

            maxGroup.Add(point);
        }

        return true;
    }

    private static int ManhattanDistance(int[] point1, int[] point2) =>
        Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);
}
