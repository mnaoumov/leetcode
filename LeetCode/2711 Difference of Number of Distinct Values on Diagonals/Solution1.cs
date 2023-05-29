using JetBrains.Annotations;

namespace LeetCode._2711_Difference_of_Number_of_Distinct_Values_on_Diagonals;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-347/submissions/detail/958697658/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] DifferenceOfDistinctValues(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var ans = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();

        for (var diff = -n + 1; diff <= m - 1; diff++)
        {
            var bottomRightCounts = new Dictionary<int, int>();

            var minI = Math.Max(0, diff);
            var maxI = Math.Min(n - 1 + diff, m - 1);

            for (var i = minI; i <= maxI; i++)
            {
                var j = i - diff;
                var num = grid[i][j];
                bottomRightCounts[num] = bottomRightCounts.GetValueOrDefault(num) + 1;
            }

            var topLeftCounts = new Dictionary<int, int>();

            for (var i = minI; i <= maxI; i++)
            {
                var j = i - diff;
                var num = grid[i][j];
                bottomRightCounts[num]--;

                if (bottomRightCounts[num] == 0)
                {
                    bottomRightCounts.Remove(num);
                }

                ans[i][j] = Math.Abs(topLeftCounts.Count - bottomRightCounts.Count);
                topLeftCounts[num] = topLeftCounts.GetValueOrDefault(num) + 1;
            }
        }

        return ans;
    }
}
