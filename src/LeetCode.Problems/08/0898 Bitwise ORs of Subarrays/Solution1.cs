namespace LeetCode.Problems._0898_Bitwise_ORs_of_Subarrays;

/// <summary>
/// https://leetcode.com/problems/bitwise-ors-of-subarrays/submissions/1717795328/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution1 : ISolution
{
    public int SubarrayBitwiseORs(int[] arr)
    {
        var n = arr.Length;

        var dp = new DynamicProgramming<int, (HashSet<int> orsOfSubarrayStartingFromIndex, HashSet<int> orsOfSubarrayAfterIndex)>((index, recursiveFunc) =>
        {
            var num = arr[index];
            var orsOfSubarrayStartingFromIndex = new HashSet<int> { num };
            var orsOfSubarrayAfterIndex = new HashSet<int> { num };

            var ans = (orsOfSubarrayStartingFromIndex, orsOfSubarrayAfterIndex);

            if (index == n - 1)
            {
                return ans;
            }

            var next = recursiveFunc(index + 1);
            orsOfSubarrayAfterIndex.UnionWith(next.orsOfSubarrayAfterIndex);

            foreach (var newOr in next.orsOfSubarrayStartingFromIndex.Select(or => or | num))
            {
                orsOfSubarrayStartingFromIndex.Add(newOr);
                orsOfSubarrayAfterIndex.Add(newOr);
            }

            return ans;
        });

        return dp.GetOrCalculate(0).orsOfSubarrayAfterIndex.Count;
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
