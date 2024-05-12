using JetBrains.Annotations;

namespace LeetCode._0864_Shortest_Path_to_Get_All_Keys;

/// <summary>
/// https://leetcode.com/submissions/detail/957945192/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ShortestPathAllKeys(string[] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const char startingPoint = '@';
        const char wall = '#';

        var queue = new Queue<(int row, int column, int keysMask)>();
        var keysCount = 0;

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                var cell = grid[row][column];

                switch (cell)
                {
                    case startingPoint:
                        queue.Enqueue((row, column, 0));
                        break;
                    case >= 'a' and <= 'z':
                        keysCount++;
                        break;
                }
            }
        }

        var allKeysMask = (1 << keysCount) - 1;

        var movesCount = 0;

        int count;
        var seen = new HashSet<(int row, int column, int keysMask)>();
        var directions = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        while ((count = queue.Count) > 0)
        {
            for (var i = 0; i < count; i++)
            {
                var (row, column, keysMask) = queue.Dequeue();

                if (row < 0 || column < 0 || row >= m || column >= n)
                {
                    continue;
                }

                if (!seen.Add((row, column, keysMask)))
                {
                    continue;
                }

                var cell = grid[row][column];

                switch (cell)
                {
                    case wall:
                        continue;
                    case >= 'a' and <= 'z':
                    {
                        var keyIndex = cell - 'a';
                        keysMask |= 1 << keyIndex;

                        if (keysMask == allKeysMask)
                        {
                            return movesCount;
                        }

                        break;
                    }
                    case >= 'A' and <= 'Z':
                    {
                        var lockIndex = cell - 'A';

                        if ((keysMask & 1 << lockIndex) == 0)
                        {
                            continue;
                        }

                        break;
                    }
                }

                foreach (var (dRow, dColumn) in directions)
                {
                    queue.Enqueue((row + dRow, column + dColumn, keysMask));
                }
            }

            movesCount++;
        }

        return -1;
    }
}
