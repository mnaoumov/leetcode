namespace LeetCode.Problems._3710_Maximum_Partition_Factor;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-167/problems/maximum-partition-factor/submissions/1798446342/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
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
        var n = points.Length;
        var withinFactorMap = Enumerable.Range(0, n).Select(_ => new List<int>()).ToArray();

        for (var i = 0; i < n; i++)
        {
            var point1 = points[i];

            for (var j = i + 1; j < n; j++)
            {
                var point2 = points[j];

                if (ManhattanDistance(point1, point2) >= factor)
                {
                    continue;
                }

                withinFactorMap[i].Add(j);
                withinFactorMap[j].Add(i);
            }
        }

        var group1 = new HashSet<int>();
        var group2 = new HashSet<int>();

        for (var i = 0; i < n; i++)
        {
            var group1Copy = group1.ToHashSet();
            var group2Copy = group2.ToHashSet();

            if (Dfs(i, group1Copy, group2Copy))
            {
                group1 = group1Copy;
                group2 = group2Copy;
                continue;
            }

            group1Copy = group1.ToHashSet();
            group2Copy = group2.ToHashSet();

            // ReSharper disable once InvertIf
            if (Dfs(i, group2Copy, group1Copy))
            {
                group1 = group1Copy;
                group2 = group2Copy;
                continue;
            }

            return false;
        }

        return true;

        bool Dfs(int index, HashSet<int> group, HashSet<int> otherGroup)
        {
            if (group.Contains(index))
            {
                return true;
            }

            if (otherGroup.Contains(index))
            {
                return false;
            }

            group.Add(index);
            return withinFactorMap[index].All(otherIndex => Dfs(otherIndex, otherGroup, group));
        }
    }

    private static int ManhattanDistance(int[] point1, int[] point2) =>
        Math.Abs(point1[0] - point2[0]) + Math.Abs(point1[1] - point2[1]);
}
