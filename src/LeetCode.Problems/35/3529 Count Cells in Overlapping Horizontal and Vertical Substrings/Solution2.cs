namespace LeetCode.Problems._3529_Count_Cells_in_Overlapping_Horizontal_and_Vertical_Substrings;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-155/problems/count-cells-in-overlapping-horizontal-and-vertical-substrings/submissions/1618513473/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int CountCells(char[][] grid, string pattern)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var rowsStr = string.Concat(grid.Select(row => string.Concat(row)));
        var columnsStr = string.Concat(Enumerable.Range(0, n)
            .Select(columnIndex => string.Concat(grid.Select(row => row[columnIndex]))));

        var cellMatchCounts = new bool[m, n];

        var rowStrIndices = FindAllIndices(rowsStr, pattern);

        var nextIndexToProcess = 0;

        foreach (var rowStrIndex in rowStrIndices)
        {
            for (var index = Math.Max(rowStrIndex, nextIndexToProcess); index < rowStrIndex + pattern.Length; index++)
            {
                var rowIndex = index / n;
                var columnIndex = index % n;
                cellMatchCounts[rowIndex, columnIndex] = true;
            }

            nextIndexToProcess = rowStrIndex + pattern.Length;
        }

        var columnStrIndices = FindAllIndices(columnsStr, pattern);
        nextIndexToProcess = 0;
        var ans = 0;

        foreach (var columnStrIndex in columnStrIndices)
        {
            for (var index = Math.Max(columnStrIndex, nextIndexToProcess); index < columnStrIndex + pattern.Length; index++)
            {
                var rowIndex = index % m;
                var columnIndex = index / m;
                if (cellMatchCounts[rowIndex, columnIndex])
                {
                    ans++;
                }
            }

            nextIndexToProcess = columnStrIndex + pattern.Length;
        }

        return ans;
    }

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

            indices.Add(nextIndex);
            lastIndex = nextIndex;
        }

        return indices.ToArray();
    }
}
