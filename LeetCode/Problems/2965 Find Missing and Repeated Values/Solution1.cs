using JetBrains.Annotations;

namespace LeetCode._2965_Find_Missing_and_Repeated_Values;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-376/submissions/detail/1121421000/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindMissingAndRepeatedValues(int[][] grid)
    {
        var n = grid.Length;

        var set = new HashSet<int>();
        var ans = new int[2];

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var num = grid[i][j];

                if (!set.Add(num))
                {
                    ans[0] = num;
                }
            }
        }

        var totalSum = n * n * (1 + n * n) / 2;
        ans[1] = totalSum - set.Sum();
        return ans;
    }
}
