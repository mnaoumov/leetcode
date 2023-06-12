using JetBrains.Annotations;

namespace LeetCode._0490_The_Maze;

/// <summary>
/// https://leetcode.com/submissions/detail/969785786/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasPath(int[][] maze, int[] start, int[] destination)
    {
        const int empty = 0;
        var m = maze.Length;
        var n = maze[0].Length;

        var seen = new bool[m, n];
        var directions = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        return Dfs(start[0], start[1]);

        bool Dfs(int row, int column)
        {
            if (seen[row, column])
            {
                return false;
            }

            seen[row, column] = true;

            if (row == destination[0] && column == destination[1])
            {
                return true;
            }

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row;
                var nextColumn = column;

                while (true)
                {
                    nextRow += dRow;
                    nextColumn += dColumn;

                    if (nextRow >= 0 && nextColumn >= 0 && nextRow < m && nextColumn < n &&
                        maze[nextRow][nextColumn] == empty)
                    {
                        continue;
                    }

                    nextRow -= dRow;
                    nextColumn -= dColumn;

                    if ((nextRow, nextColumn) == (row, column) || !Dfs(nextRow, nextColumn))
                    {
                        break;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
