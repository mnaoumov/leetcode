using JetBrains.Annotations;

namespace LeetCode._1199_Minimum_Time_to_Build_Blocks;

/// <summary>
/// https://leetcode.com/submissions/detail/1037239486/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinBuildTime(int[] blocks, int split)
    {
        blocks = blocks.OrderBy(block => block).ToArray();

        var dp = new DynamicProgramming<(int blocksCount, int workersCount), int>((key, recursiveFunc) =>
        {
            var (blocksCount, workersCount) = key;

            if (blocksCount == 0)
            {
                return 0;
            }

            if (workersCount == 0)
            {
                return int.MaxValue;
            }

            var maxBlock = blocks[blocksCount - 1];
            var ans = Math.Max(maxBlock, recursiveFunc((blocksCount - 1, workersCount - 1)));

            if (workersCount < blocksCount)
            {
                ans = Math.Min(ans, split + recursiveFunc((blocksCount, Math.Min(2 * workersCount, blocksCount))));
            }

            return ans;
        });

        return dp.GetOrCalculate((blocks.Length, 1));
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
