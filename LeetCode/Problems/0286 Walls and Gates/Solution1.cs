using JetBrains.Annotations;

namespace LeetCode.Problems._0286_Walls_and_Gates;

/// <summary>
/// https://leetcode.com/submissions/detail/946336899/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void WallsAndGates(int[][] rooms)
    {
        var m = rooms.Length;
        var n = rooms[0].Length;
        const int wall = -1;
        const int gate = 0;
        const int empty = int.MaxValue;

        var directions = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (rooms[i][j] != empty)
                {
                    continue;
                }

                var seen = new bool[m, n];
                var distance = 0;

                var queue = new Queue<(int row, int column)>();
                queue.Enqueue((i, j));
                var pathFound = false;

                while (queue.Count > 0 && !pathFound)
                {
                    var count = queue.Count;

                    for (var k = 0; k < count; k++)
                    {
                        var (row, column) = queue.Dequeue();

                        if (rooms[row][column] == gate)
                        {
                            pathFound = true;
                            rooms[i][j] = distance;
                            break;
                        }

                        seen[row, column] = true;

                        if (rooms[row][column] == wall)
                        {
                            continue;
                        }

                        foreach (var (dRow, dColumn) in directions)
                        {
                            var nextRow = row + dRow;
                            var nextColumn = column + dColumn;

                            if (nextRow < 0 || nextColumn < 0 || nextRow >= m || nextColumn >= n)
                            {
                                continue;
                            }

                            if (seen[nextRow, nextColumn])
                            {
                                continue;
                            }

                            queue.Enqueue((nextRow, nextColumn));
                        }
                    }

                    distance++;
                }
            }
        }
    }
}
