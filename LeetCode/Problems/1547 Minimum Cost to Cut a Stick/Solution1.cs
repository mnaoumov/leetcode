using JetBrains.Annotations;

namespace LeetCode.Problems._1547_Minimum_Cost_to_Cut_a_Stick;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int n, int[] cuts)
    {
        var cutsSet = new SortedSet<int>(cuts);

        var dp = new DynamicProgramming<(int from, int to), int>((key, recursiveFunc) =>
        {
            var (from, to) = key;

            if (to - from == 1)
            {
                return 0;
            }

            var ans = int.MaxValue;
            var hasCuts = false;

            foreach (var cost in cutsSet.GetViewBetween(from + 1, to - 1).Select(index => recursiveFunc((from, index)) + recursiveFunc((index, to)) + to - from))
            {
                ans = Math.Min(ans, cost);
                hasCuts = true;
            }

            return !hasCuts ? 0 : ans;
        });

        return dp.GetOrCalculate((0, n));
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
