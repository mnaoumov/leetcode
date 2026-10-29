namespace LeetCode.Problems._3509_Maximum_Product_of_Subsequences_With_an_Alternating_Sum_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-444/problems/maximum-product-of-subsequences-with-an-alternating-sum-equal-to-k/submissions/1598122739/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxProduct(int[] nums, int k, int limit)
    {
        var n = nums.Length;
        const int impossible = -1;
        const int unlimited = int.MaxValue;

        var dp = new DynamicProgramming<(int index, int alternatingSum, int maxProduct, bool isEmpty), int>((key, recursiveFunc) =>
        {
            var (index, alternatingSum, maxProduct, isEmpty) = key;

            var ans = alternatingSum == 0 && !isEmpty && maxProduct >= 1 ? 1 : impossible;

            if (index == n)
            {
                return ans;
            }

            ans = Math.Max(ans, recursiveFunc((index + 1, alternatingSum, maxProduct, isEmpty)));

            var num = nums[index];
            var nextMaxProduct = num == 0 || maxProduct == unlimited ? unlimited : maxProduct / num;
            var nextResult = recursiveFunc((index + 1, num - alternatingSum, nextMaxProduct, false));
            if (nextResult != impossible)
            {
                ans = Math.Max(ans, num * nextResult);
            }
            return ans;
        });

        return dp.GetOrCalculate((0, k, limit, true));
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
