namespace LeetCode.Problems._0694_Number_of_Distinct_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/970846563/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumDistinctIslands(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var directions = new (int di, int dj)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var set = new HashSet<string>();

        var seen = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var list = new List<(int i, int j)>();
                Dfs(i, j, list);

                if (list.Count == 0)
                {
                    continue;
                }

                var minI = list.Select(x => x.i).Min();
                var minJ = list.Select(x => x.j).Min();

                var shift = list.Select(x => (i: x.i - minI, j: x.j - minJ)).OrderBy(x => x.i).ThenBy(x => x.j);
                var str = string.Join(';', shift.Select(x => x.ToString()));
                set.Add(str);
            }
        }

        return set.Count;

        void Dfs(int i, int j, ICollection<(int i, int j)> list)
        {
            if (seen[i, j])
            {
                return;
            }

            seen[i, j] = true;

            if (grid[i][j] != 1)
            {
                return;
            }

            list.Add((i, j));

            foreach (var (di, dj) in directions)
            {
                var nextI = i + di;
                var nextJ = j + dj;

                if (nextI < 0 || nextJ < 0 || nextI >= m || nextJ >= n)
                {
                    continue;
                }

                Dfs(nextI, nextJ, list);
            }
        }
    }
}
