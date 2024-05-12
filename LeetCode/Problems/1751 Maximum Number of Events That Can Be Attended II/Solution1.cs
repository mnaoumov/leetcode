using JetBrains.Annotations;

namespace LeetCode.Problems._1751_Maximum_Number_of_Events_That_Can_Be_Attended_II;

/// <summary>
/// https://leetcode.com/submissions/detail/949164500/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxValue(int[][] events, int k)
    {
        var eventObjs = events.Select(arr => (startDay: arr[0], endDay: arr[1], value: arr[2])).OrderBy(e => e.startDay)
            .ToArray();


        var dp = new DynamicProgramming<(int index, int eventsLeft), int>((key, recursiveFunc) =>
        {
            var (index, eventsLeft) = key;

            if (index == events.Length)
            {
                return 0;
            }

            if (eventsLeft == 0)
            {
                return 0;
            }

            var ans = Math.Max(eventObjs[index].value, recursiveFunc((index + 1, eventsLeft)));

            for (var i = index + 1; i < events.Length; i++)
            {
                if (eventObjs[i].startDay <= eventObjs[index].endDay)
                {
                    continue;
                }

                ans = Math.Max(ans, eventObjs[index].value + recursiveFunc((i, eventsLeft - 1)));
                break;
            }

            return ans;
        });

        return dp.GetOrCalculate((0, k));
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
