namespace LeetCode.Problems._0302_Smallest_Rectangle_Enclosing_Black_Pixels;

/// <summary>
/// https://leetcode.com/problems/smallest-rectangle-enclosing-black-pixels/submissions/1614135987/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinArea(char[][] image, int x, int y)
    {
        var queue = new Queue<(int row, int column)>();
        queue.Enqueue((x, y));

        var m = image.Length;
        var n = image[0].Length;
        var visited = new bool[m, n];
        var directions = new[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        var minRow = int.MaxValue;
        var maxRow = int.MinValue;
        var minColumn = int.MaxValue;
        var maxColumn = int.MinValue;

        while (queue.Count > 0)
        {
            var (row, column) = queue.Dequeue();

            if (image[row][column] == '0')
            {
                continue;
            }

            if (visited[row, column])
            {
                continue;
            }

            visited[row, column] = true;

            minRow = Math.Min(minRow, row);
            maxRow = Math.Max(maxRow, row);
            minColumn = Math.Min(minColumn, column);
            maxColumn = Math.Max(maxColumn, column);

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;
                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                queue.Enqueue((nextRow, nextColumn));
            }
        }

        return (maxRow - minRow + 1) * (maxColumn - minColumn + 1);
    }
}
