using JetBrains.Annotations;

namespace LeetCode._2639_Find_the_Width_of_Columns_of_a_Grid;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-102/submissions/detail/934164314/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindColumnWidth(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        return Enumerable.Range(0, n)
            .Select(j => Enumerable.Range(0, m).Max(i => NumberLength(grid[i][j])))
            .ToArray();
    }

    private static int NumberLength(int num)
    {
        switch (num)
        {
            case < 0:
                return 1 + NumberLength(-num);
            case 0:
                return 1;
            case > 0:
                var result = 0;
                while (num > 0)
                {
                    result++;
                    num /= 10;
                }

                return result;
        }
    }
}
