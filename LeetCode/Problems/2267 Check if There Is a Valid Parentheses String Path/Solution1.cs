namespace LeetCode.Problems._2267_Check_if_There_Is_a_Valid_Parentheses_String_Path;

/// <summary>
/// https://leetcode.com/problems/check-if-there-is-a-valid-parentheses-string-path/submissions/2156523365/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasValidPath(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const char openBracket = '(';

        var dp = new DynamicProgramming<(int row, int column, int balance), bool>((key, getOrCalculate) =>
        {
            var (row, column, balance) = key;

            var isOpen = grid[row][column] == openBracket;
            balance += isOpen ? 1 : -1;

            if (balance < 0)
            {
                return false;
            }

            if (row == m - 1 && column == n - 1)
            {
                return balance == 0;
            }

            if (row < m - 1 && getOrCalculate((row + 1, column, balance)))
            {
                return true;
            }

            if (column < n - 1 && getOrCalculate((row, column + 1, balance)))
            {
                return true;
            }

            return false;
        });

        return dp.GetOrCalculate((0, 0, 0));
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
