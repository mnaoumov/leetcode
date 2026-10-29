namespace LeetCode.Problems._3529_Count_Cells_in_Overlapping_Horizontal_and_Vertical_Substrings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-155/problems/count-cells-in-overlapping-horizontal-and-vertical-substrings/submissions/1618497638/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int CountCells(char[][] grid, string pattern)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var rowsStr = string.Concat(grid.Select(row => string.Concat(row)));
        var columnsStr = string.Concat(Enumerable.Range(0, n)
            .Select(columnIndex => string.Concat(grid.Select(row => row[columnIndex]))));

        var rowStrIndices = FindAllIndices(rowsStr, pattern);
        var rowStrCells = rowStrIndices.Select(RowIndexToCell).ToHashSet();
        var columnStrIndices = FindAllIndices(columnsStr, pattern);
        var columnStrCells = columnStrIndices.Select(ColumnIndexToCell).ToHashSet();

        rowStrCells.IntersectWith(columnStrCells);
        return rowStrCells.Count;

        Cell RowIndexToCell(int rowIndex) => new(rowIndex / n, rowIndex % n);
        Cell ColumnIndexToCell(int columnIndex) => new(columnIndex % m, columnIndex / m);
    }

    private record Cell(int Row, int Column);

    private static int[] FindAllIndices(string str, string pattern)
    {
        var indices = new SortedSet<int>();

        var lastIndex = -1;

        while (true)
        {
            var nextIndex = str.IndexOf(pattern, lastIndex + 1, StringComparison.Ordinal);
            if (nextIndex == -1)
            {
                break;
            }

            indices.UnionWith(Enumerable.Range(nextIndex, pattern.Length));
            lastIndex = nextIndex;
        }

        return indices.ToArray();
    }
}
