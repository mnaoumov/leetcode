using JetBrains.Annotations;

namespace LeetCode.Problems._0983_Minimum_Cost_For_Tickets;

/// <summary>
/// https://leetcode.com/submissions/detail/923323583/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable once IdentifierTypo
    public int MincostTickets(int[] days, int[] costs)
    {
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index >= days.Length)
            {
                return 0;
            }

            return new[]
            {
                costs[0] + GetNextCost(1),
                costs[1] + GetNextCost(7),
                costs[2] + GetNextCost(30)
            }.Min();

            int GetNextCost(int shift)
            {
                var nextDay = days[index] + shift;
                var dayIndex = Array.BinarySearch(days, nextDay);

                if (dayIndex < 0)
                {
                    dayIndex = ~dayIndex;
                }

                return recursiveFunc(dayIndex);
            }
        });

        return dp.GetOrCalculate(0);
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
