using JetBrains.Annotations;

namespace LeetCode._1235_Maximum_Profit_in_Job_Scheduling;

/// <summary>
/// https://leetcode.com/submissions/detail/850345743/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
    {
        var records = startTime.Zip(endTime, profit).Cast<(int startTime, int endTime, int profit)>().OrderBy(x => x.startTime).ThenBy(x => x.endTime).ToArray();

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == records.Length)
            {
                return 0;
            }

            var result = recursiveFunc(index + 1);

            int j;

            for (j = index + 1; j < records.Length; j++)
            {
                if (records[j].startTime >= records[index].endTime)
                {
                    break;
                }
            }

            result = Math.Max(result, records[index].profit + recursiveFunc(j));

            return result;
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
