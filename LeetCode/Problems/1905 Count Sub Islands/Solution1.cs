namespace LeetCode.Problems._1905_Count_Sub_Islands;

/// <summary>
/// https://leetcode.com/submissions/detail/924544351/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountSubIslands(int[][] grid1, int[][] grid2)
    {
        var m = grid1.Length;
        var n = grid1[0].Length;

        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var islandIndices1 = new Dictionary<(int i, int j), int>();
        var lastIndex1 = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid1[i][j] != 1)
                {
                    continue;
                }

                if (islandIndices1.ContainsKey((i, j)))
                {
                    continue;
                }

                lastIndex1++;

                Dfs1(i, j);
            }
        }

        var isSubIslands = new Dictionary<(int i, int j), bool>();
        var result = 0;
        int lastIndex2;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (grid2[i][j] != 1)
                {
                    continue;
                }

                if (isSubIslands.ContainsKey((i, j)))
                {
                    continue;
                }

                lastIndex2 = islandIndices1.GetValueOrDefault((i, j));

                if (Dfs2(i, j))
                {
                    result++;
                }
            }
        }

        return result;

        void Dfs1(int i, int j)
        {
            if (!Validate(i, j))
            {
                return;
            }

            if (grid1[i][j] != 1)
            {
                return;
            }

            if (islandIndices1.ContainsKey((i, j)))
            {
                return;
            }

            islandIndices1[(i, j)] = lastIndex1;

            foreach (var (di, dj) in directions)
            {
                Dfs1(i + di, j + dj);
            }
        }

        bool Dfs2(int i, int j)
        {
            if (!Validate(i, j))
            {
                return true;
            }

            if (grid2[i][j] != 1)
            {
                return true;
            }

            if (isSubIslands.TryGetValue((i, j), out var isSubIsland))
            {
                return isSubIsland;
            }

            isSubIsland = lastIndex2 > 0 && islandIndices1.GetValueOrDefault((i, j)) == lastIndex2;

            isSubIslands[(i, j)] = isSubIsland;

            foreach (var (di, dj) in directions)
            {
                isSubIsland &= Dfs2(i + di, j + dj);
            }

            isSubIslands[(i, j)] = isSubIsland;
            return isSubIsland;
        }

        bool Validate(int i, int j) => 0 <= i && i < m && 0 <= j && j < n;
    }
}
