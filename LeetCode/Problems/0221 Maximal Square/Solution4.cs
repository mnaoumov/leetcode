using JetBrains.Annotations;

namespace LeetCode._0221_Maximal_Square;

/// <summary>
/// https://leetcode.com/submissions/detail/871195468/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MaximalSquare(char[][] matrix)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var dp = new DynamicProgramming<(int row, int column), int>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            if (row >= m || column >= n)
            {
                return 0;
            }

            if (matrix[row][column] == '0')
            {
                return 0;
            }

            var downMaxSize = recursiveFunc((row + 1, column));
            var rightMaxSize = recursiveFunc((row, column + 1));
            var result = 1 + Math.Min(downMaxSize, rightMaxSize);

            if (matrix[row - 1 + result][column - 1 + result] == '0')
            {
                result--;
            }

            return result;
        });

        var maxSize = 0;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                maxSize = Math.Max(maxSize, dp.GetOrCalculate((i, j)));
            }
        }

        return maxSize * maxSize;
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
