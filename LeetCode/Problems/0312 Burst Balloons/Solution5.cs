using JetBrains.Annotations;

namespace LeetCode.Problems._0312_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/881579783/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public int MaxCoins(int[] nums)
    {
        var dp = new DynamicProgramming<string, int>((key, recursiveFunc) =>
        {
            var list = ParseKey(key);

            if (list.Count == 1)
            {
                return list[0];
            }

            var result = int.MinValue;

            for (var i = 0; i < list.Count; i++)
            {
                var num = list[i];
                var currentBalloonCost = num * (i > 0 ? list[i - 1] : 1) * (i + 1 < list.Count ? list[i + 1] : 1);
                list.RemoveAt(i);
                var otherBalloonsCost = recursiveFunc(MakeKey(list));
                list.Insert(i, num);
                result = Math.Max(result, currentBalloonCost + otherBalloonsCost);
            }

            return result;
        });

        return dp.GetOrCalculate(MakeKey(nums));
    }

    private static List<int> ParseKey(string key) => key.Split(',').Select(str => Convert.ToInt32(str)).ToList();

    private static string MakeKey(IEnumerable<int> nums) => string.Join(",", nums);

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
