using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2611_Mice_and_Cheese;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-339/submissions/detail/926294891/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MiceAndCheese(int[] reward1, int[] reward2, int k)
    {
        var n = reward1.Length;

        var dp = new DynamicProgramming<(int index, int cheesesToEatCount1), int>((key, recursiveFunc) =>
        {
            var (index, cheesesToEatCount1) = key;

            if (cheesesToEatCount1 == 0)
            {
                return reward2.Skip(index).Sum();
            }

            if (index + cheesesToEatCount1 == n)
            {
                return reward1.Skip(index).Sum();
            }

            return Math.Max(
                reward1[index] + recursiveFunc((index + 1, cheesesToEatCount1 - 1)),
                reward2[index] + recursiveFunc((index + 1, cheesesToEatCount1)));
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
