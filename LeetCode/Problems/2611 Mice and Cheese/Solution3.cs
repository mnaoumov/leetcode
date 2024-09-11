using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2611_Mice_and_Cheese;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-339/submissions/detail/926304793/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution3 : ISolution
{
    public int MiceAndCheese(int[] reward1, int[] reward2, int k)
    {
        var n = reward1.Length;
        var suffixSums1 = new int[n + 1];
        var suffixSums2 = new int[n + 1];

        for (var i = n - 1; i >= 0; i--)
        {
            suffixSums1[i] = suffixSums1[i + 1] + reward1[i];
            suffixSums2[i] = suffixSums2[i + 1] + reward2[i];
        }

        var dp = new DynamicProgramming<(int index, int cheesesToEatCount1), int>((key, recursiveFunc) =>
        {
            var (index, cheesesToEatCount1) = key;

            if (cheesesToEatCount1 == 0)
            {
                return suffixSums2[index];
            }

            if (index + cheesesToEatCount1 == n)
            {
                return suffixSums1[index];
            }

            var result = int.MinValue;

            for (var i = index; i <= n - cheesesToEatCount1; i++)
            {
                result = Math.Max(result,
                    suffixSums2[index] - suffixSums2[i] + reward1[i] + recursiveFunc((i + 1, cheesesToEatCount1 - 1)));
            }

            return result;
        });

        return dp.GetOrCalculate((0, k));
    }

    private class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func)
        {
            _func = func;
        }

        public TValue GetOrCalculate(TKey key)
        {
            if (!_cache.TryGetValue(key, out var value))
            {
                _cache[key] = value = _func(key, GetOrCalculate);
            }

            return value;
        }
    }
}
