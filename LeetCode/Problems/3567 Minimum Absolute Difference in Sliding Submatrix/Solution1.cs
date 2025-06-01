namespace LeetCode.Problems._3567_Minimum_Absolute_Difference_in_Sliding_Submatrix;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-452/problems/minimum-absolute-difference-in-sliding-submatrix/submissions/1650265422/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] MinAbsDiff(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var ans = Enumerable.Range(0, m - k + 1)
            .Select(_ => new int[n - k + 1])
            .ToArray();

        for (var i = 0; i < m - k + 1; i++)
        {
            for (var j = 0; j < n - k + 1; j++)
            {
                var set = new SortedSet<int>();

                for (var s = 0; s < k; s++)
                {
                    for (var t = 0; t < k; t++)
                    {
                        set.Add(grid[i + s][j + t]);
                    }
                }

                var arr = set.ToArray();

                if (arr.Length == 1)
                {
                    continue;
                }

                ans[i][j] = Enumerable.Range(0, arr.Length - 1).Select(u => Math.Abs(arr[u + 1] - arr[u])).Min();
            }
        }

        return ans;
    }
}
