using System.Numerics;

namespace LeetCode.Problems._3733_Minimum_Time_to_Complete_All_Deliveries;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-474/problems/minimum-time-to-complete-all-deliveries/submissions/1818287240/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public long MinimumTime(int[] d, int[] r)
    {
        var rechargePeriod1 = r[0];
        var rechargePeriod2 = r[1];
        var commonRechargePeriod = 1L * rechargePeriod1 * rechargePeriod2 /
                                   (int) BigInteger.GreatestCommonDivisor(rechargePeriod1, rechargePeriod2);

        var dp = new DynamicProgramming<(int deliveriesLeft1, int deliveriesLeft2, long startingTimeModCommonPeriod), long>((key, getOrCalculate) =>
        {
            var (deliveriesLeft1, deliveriesLeft2, startingTimeModCommonPeriod) = key;

            if (deliveriesLeft1 == 0 && deliveriesLeft2 == 0)
            {
                return 0;
            }

            var nextStartingTimeModCommonPeriod = (startingTimeModCommonPeriod + 1) % commonRechargePeriod;

            var ans = long.MaxValue;

            if (deliveriesLeft1 > 0 && startingTimeModCommonPeriod % rechargePeriod1 != 0)
            {
                ans = Math.Min(ans,
                    1 + getOrCalculate((deliveriesLeft1 - 1, deliveriesLeft2, nextStartingTimeModCommonPeriod)));
            }

            if (deliveriesLeft2 > 0 && startingTimeModCommonPeriod % rechargePeriod2 != 0)
            {
                ans = Math.Min(ans,
                    1 + getOrCalculate((deliveriesLeft1, deliveriesLeft2 - 1, nextStartingTimeModCommonPeriod)));
            }

            if (ans == long.MaxValue)
            {
                ans = 1 + getOrCalculate((deliveriesLeft1, deliveriesLeft2, nextStartingTimeModCommonPeriod));
            }

            return ans;
        });

        return dp.GetOrCalculate((d[0], d[1], 1));
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
