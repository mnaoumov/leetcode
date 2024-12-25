namespace LeetCode.Problems._3376_Minimum_Time_to_Break_Locks_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-145/submissions/detail/1472751530/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    // ReSharper disable once InconsistentNaming
    public int FindMinimumTime(IList<int> strength, int K)
    {
        var dp = new DynamicProgramming<(int energy, int energyFactor, string strengthStr), int>((key, recursiveFunc) =>
        {
            var (energy, energyFactor, strengthStr) = key;
            var sortedStrengths = strengthStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            if (sortedStrengths.Count == 0)
            {
                return 0;
            }

            var index = sortedStrengths.BinarySearch(energy);
            if (index < 0)
            {
                index = ~index - 1;
            }

            var ans = int.MaxValue;

            if (index >= 0 && sortedStrengths[index] <= energy)
            {
                var removed = sortedStrengths[index];
                sortedStrengths.RemoveAt(index);
                ans = Math.Min(ans, 1 +
                    recursiveFunc((energyFactor + K, energyFactor + K, string.Join(' ', sortedStrengths))));
                sortedStrengths.Insert(index, removed);
            }

            if (index < sortedStrengths.Count - 1)
            {
                ans = Math.Min(ans, 1 + recursiveFunc((energy + energyFactor, energyFactor, strengthStr)));
            }

            return ans;
        });

        return dp.GetOrCalculate((1, 1, string.Join(' ', strength.OrderBy(x => x))));
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
