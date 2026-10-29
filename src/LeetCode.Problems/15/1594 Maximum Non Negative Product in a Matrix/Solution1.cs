namespace LeetCode.Problems._1594_Maximum_Non_Negative_Product_in_a_Matrix;

/// <summary>
/// https://leetcode.com/problems/maximum-non-negative-product-in-a-matrix/submissions/1956223774/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProductPath(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var dp = new DynamicProgramming<(int row, int column), MinMaxProduct>((key, getOrCalculate) =>
        {
            var (row, column) = key;

            var num = grid[row][column];

            if (row == m - 1 && column == n - 1)
            {
                return new MinMaxProduct(num, num);
            }

            var ans = new MinMaxProduct(long.MaxValue, long.MinValue);

            if (row + 1 < m)
            {
                var subResult = getOrCalculate((row + 1, column));
                ans = ans.MinMax(subResult.Add(num));
            }

            // ReSharper disable once InvertIf
            if (column + 1 < n)
            {
                var subResult = getOrCalculate((row, column + 1));
                ans = ans.MinMax(subResult.Add(num));
            }

            return ans;
        });

        const int modulo = 1_000_000_007;
        var result = dp.GetOrCalculate((0, 0));

        return result.MaxProduct >= 0 ? (int) (result.MaxProduct % modulo) : -1;
    }

    private sealed record MinMaxProduct(long MinProduct, long MaxProduct)
    {
        public MinMaxProduct MinMax(MinMaxProduct minMaxProduct) =>
            new(Math.Min(MinProduct, minMaxProduct.MinProduct), Math.Max(MaxProduct, minMaxProduct.MaxProduct));

        public MinMaxProduct Add(int num) => num >= 0
            ? new MinMaxProduct(MinProduct * num, MaxProduct * num)
            : new MinMaxProduct(MaxProduct * num, MinProduct * num);
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
