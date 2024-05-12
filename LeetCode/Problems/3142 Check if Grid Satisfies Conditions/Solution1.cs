using JetBrains.Annotations;

namespace LeetCode.Problems._3142_Check_if_Grid_Satisfies_Conditions;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-130/submissions/detail/1255215210/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool SatisfiesConditions(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i + 1 < m && grid[i][j] != grid[i + 1][j])
                {
                    return false;
                }

                if (j + 1 < n && grid[i][j] == grid[i][j + 1])
                {
                    return false;
                }
            }
        }

        return true;
    }
}
