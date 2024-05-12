using JetBrains.Annotations;

namespace LeetCode._2352_Equal_Row_and_Column_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/856811672/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int EqualPairs(int[][] grid)
    {
        var n = grid.Length;
        var rowCounts = new Dictionary<string, int>();

        for (var i = 0; i < n; i++)
        {
            var row = grid[i];
            var key = ToKey(row);
            rowCounts[key] = rowCounts.GetValueOrDefault(key) + 1;
        }

        var result = 0;

        for (var i = 0; i < n; i++)
        {
            var i1 = i;
            var column = grid.Select(row => row[i1]);
            result += rowCounts.GetValueOrDefault(ToKey(column));
        }

        return result;
    }

    private static string ToKey(IEnumerable<int> items) => string.Join(' ', items);
}
