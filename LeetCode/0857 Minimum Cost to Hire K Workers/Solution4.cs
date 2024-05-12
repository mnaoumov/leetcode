using JetBrains.Annotations;

namespace LeetCode._0857_Minimum_Cost_to_Hire_K_Workers;

/// <summary>
/// https://leetcode.com/submissions/detail/1255788738/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public double MincostToHireWorkers(int[] quality, int[] wage, int k)
    {
        var n = quality.Length;
        var rates = Enumerable.Range(0, n).Select(index => 1d * wage[index] / quality[index]).ToArray();
        var orderedRateIndices = Enumerable.Range(0, n).OrderByDescending(index => rates[index]).ToArray();

        var dp = new DynamicProgramming<(int index, int count, double rate), double>((key, recursiveFunc) =>
        {
            var (index, count, rate) = key;

            if (count == 0)
            {
                return 0;
            }

            var newWage = 1d * rate * quality[orderedRateIndices[index]];
            var ans = newWage + recursiveFunc((index + 1, count - 1, rate));

            if (n - 1 - index >= count)
            {
                ans = Math.Min(ans, recursiveFunc((index + 1, count, rate)));
            }

            return ans;
        });


        return Enumerable.Range(0, n - k + 1)
            .Select(index => dp.GetOrCalculate((index, k, rates[orderedRateIndices[index]]))).Min();
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
