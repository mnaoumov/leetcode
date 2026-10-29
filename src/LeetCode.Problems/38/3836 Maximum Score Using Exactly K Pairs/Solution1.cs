namespace LeetCode.Problems._3836_Maximum_Score_Using_Exactly_K_Pairs;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-488/problems/maximum-score-using-exactly-k-pairs/submissions/1911963853/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        var n = nums1.Length;
        var m = nums2.Length;

        var dp = new DynamicProgramming<(int index1, int index2, int pairsLeft), long>((key, getOrCalculate) =>
        {
            var (index1, index2, pairsLeft) = key;

            if (pairsLeft == 0)
            {
                return 0L;
            }

            var ans = long.MinValue;

            if (index1 + pairsLeft < n)
            {
                ans = Math.Max(ans, getOrCalculate((index1 + 1, index2, pairsLeft)));
            }

            if (index2 + pairsLeft < m)
            {
                ans = Math.Max(ans, getOrCalculate((index1, index2 + 1, pairsLeft)));
            }

            ans = Math.Max(ans,
                1L * nums1[index1] * nums2[index2] + getOrCalculate((index1 + 1, index2 + 1, pairsLeft - 1)));

            return ans;
        });

        return dp.GetOrCalculate((0, 0, k));
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
