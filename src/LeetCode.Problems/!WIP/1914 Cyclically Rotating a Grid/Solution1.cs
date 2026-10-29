namespace LeetCode.Problems._1914_Cyclically_Rotating_a_Grid;

/// <summary>
/// https://leetcode.com/problems/cyclically-rotating-a-grid/submissions/1998549915/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] RotateGrid(int[][] grid, int k)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var ans = grid.Select(row => row.ToArray()).ToArray();

        for (var layerIndex = 0; layerIndex < Math.Min(m, n) / 2; layerIndex++)
        {
            var p = GetPerimeter(layerIndex);
            var k2 = k % p;

            if (k2 == 0)
            {
                continue;
            }

            for (var sourceIndex = 0; sourceIndex < p; sourceIndex++)
            {
                var targetIndex = (sourceIndex + k2) % p;

                var (sourceRow, sourceColumn) = GetCell(sourceIndex, layerIndex);
                var (targetRow, targetColumn) = GetCell(targetIndex, layerIndex);
                ans[targetRow][targetColumn] = grid[sourceRow][sourceColumn];
            }
        }

        return ans;

        (int row, int column) GetCell(int cellIndex, int layerIndex)
        {
            var p = GetPerimeter(layerIndex);

            if (cellIndex < 0 || cellIndex > p)
            {
                throw new ArgumentException("Wrong cell index", nameof(cellIndex));
            }

            var height = m - 1 - 2 * layerIndex;
            var width = n - 1 - 2 * layerIndex;

            if (cellIndex <= height)
            {
                return (layerIndex + cellIndex, layerIndex);
            }

            if (cellIndex <= height + width)
            {
                return (m - 1 - layerIndex, cellIndex - height + layerIndex);
            }

            if (cellIndex <= 2 * height + width)
            {
                return (m - 1 - layerIndex - (cellIndex - height - width), n - 1 - layerIndex);
            }

            return (layerIndex, n - 1 - layerIndex - (cellIndex - 2 * height - width));
        }

        int GetPerimeter(int layerIndex) => 2 * m + 2 * n - 8 * layerIndex - 4;
    }
}
