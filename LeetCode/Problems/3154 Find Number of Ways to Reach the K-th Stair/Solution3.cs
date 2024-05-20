using JetBrains.Annotations;

namespace LeetCode.Problems._3154_Find_Number_of_Ways_to_Reach_the_K_th_Stair;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-398/submissions/detail/1261851012/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int WaysToReachStair(int k)
    {
        var dp = new DynamicProgramming<(int step, int jump, bool wasPreviousGoDown), int>((key, recursiveFunc) =>
        {
            var (step, jump, wasPreviousGoDown) = key;

            var ans = 0;

            if (step == k)
            {
                ans++;
            }

            if (step > 0 && !wasPreviousGoDown)
            {
                ans += recursiveFunc((step - 1, jump, true));
            }

            var nextStep = step + (1 << jump);

            if (nextStep <= k + 1)
            {
                ans += recursiveFunc((nextStep, jump + 1, false));
            }

            return ans;
        });

        return dp.GetOrCalculate((1, 0, false));
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
