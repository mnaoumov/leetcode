using JetBrains.Annotations;

namespace LeetCode.Problems._1020_Number_of_Enclaves;

/// <summary>
/// https://leetcode.com/submissions/detail/906299825/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumEnclaves(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var seen = new bool[m, n];
        var deltas = new (int di, int dj)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };
        var result = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid[i][j] == 0)
                {
                    continue;
                }

                if (seen[i, j])
                {
                    continue;
                }

                var isEnclave = true;
                var enclaveSize = 0;

                Dfs(i, j);

                if (isEnclave)
                {
                    result += enclaveSize;
                }

                continue;

                void Dfs(int i2, int j2)
                {
                    if (i2 < 0 || i2 >= m || j2 < 0 || j2 >= n)
                    {
                        isEnclave = false;
                        return;
                    }

                    if (grid[i2][j2] == 0)
                    {
                        return;
                    }

                    if (seen[i2, j2])
                    {
                        return;
                    }

                    seen[i2, j2] = true;
                    enclaveSize++;

                    foreach (var (di, dj) in deltas)
                    {
                        Dfs(i2 + di, j2 + dj);
                    }
                }
            }
        }

        return result;
    }
}
