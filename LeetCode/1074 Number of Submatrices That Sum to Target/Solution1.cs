using JetBrains.Annotations;

namespace LeetCode._1074_Number_of_Submatrices_That_Sum_to_Target;

/// <summary>
/// https://leetcode.com/submissions/detail/1159592028/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumSubmatrixSumTarget(int[][] matrix, int target)
    {
        var m = matrix.Length;
        var n = matrix[0].Length;

        var prefixSums = new int[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                prefixSums[i, j] =
                    matrix[i][j]
                    + (i > 0 ? prefixSums[i - 1, j] : 0)
                    + (j > 0 ? prefixSums[i, j - 1] : 0)
                    - (i > 0 && j > 0 ? prefixSums[i - 1, j - 1] : 0);
            }
        }

        var dp = new DynamicProgramming<(int row, int column), int>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            if (row == m || column == n)
            {
                return 0;
            }

            var ans = recursiveFunc((row + 1, column)) + recursiveFunc((row, column + 1)) -
                      recursiveFunc((row + 1, column + 1));

            for (var i = row; i < m; i++)
            {
                for (var j = column; j < n; j++)
                {
                    var value = prefixSums[i, j]
                                - (row > 0 ? prefixSums[row - 1, j] : 0)
                                - (column > 0 ? prefixSums[i, column - 1] : 0)
                                + (row > 0 && column > 0 ? prefixSums[row - 1, column - 1] : 0);

                    if (value == target)
                    {
                        ans++;
                    }
                }
            }

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
