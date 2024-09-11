using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2831_Find_the_Longest_Equal_Subarray;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-359/submissions/detail/1026346254/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.MemoryLimitExceeded)]
public class Solution2 : ISolution
{
    public int LongestEqualSubarray(IList<int> nums, int k)
    {
        var n = nums.Count;
        var nextIndices = Enumerable.Repeat(n, n).ToArray();
        var lastIndexMap = new Dictionary<int, int>();

        for (var i = 0; i < n; i++)
        {
            var num = nums[i];

            if (lastIndexMap.TryGetValue(num, out var lastIndex))
            {
                nextIndices[lastIndex] = i;
            }

            lastIndexMap[num] = i;
        }

        var dp = new DynamicProgramming<(int index, int removalCount), int>((key, recursiveFunc) =>
        {
            var (index, removalCount) = key;

            if (index == n)
            {
                return 0;
            }

            var nextIndex = nextIndices[index];
            var nextRemovalCount = Math.Min(removalCount - (nextIndex - index - 1), n - 1 - nextIndex);
            return nextIndex < n && nextRemovalCount >= 0 ? 1 + recursiveFunc((nextIndex, nextRemovalCount)) : 1;
        });

        return Enumerable.Range(0, n).Max(index => dp.GetOrCalculate((index, Math.Min(k, n - 1 - index))));
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
