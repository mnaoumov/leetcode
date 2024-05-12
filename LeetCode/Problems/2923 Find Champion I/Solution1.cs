using JetBrains.Annotations;

namespace LeetCode._2923_Find_Champion_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-370/submissions/detail/1091685147/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FindChampion(int[][] grid)
    {
        var n = grid.Length;

        for (var i = 0; i < n; i++)
        {
            var found = true;

            for (var j = 0; j < n; j++)
            {
                if (j == i)
                {
                    continue;
                }

                if (grid[i][j] != 0)
                {
                    continue;
                }

                found = false;
                break;
            }

            if (found)
            {
                return i;
            }
        }

        throw new NotSupportedException();
    }
}
