using JetBrains.Annotations;

namespace LeetCode._0312_Burst_Balloons;

/// <summary>
/// https://leetcode.com/submissions/detail/881578038/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution4 : ISolution
{
    public int MaxCoins(int[] nums)
    {
        var dp = new DynamicProgramming<string, int>((key, recursiveFunc) =>
        {
            var arr = ParseKey(key);

            if (arr.Length == 1)
            {
                return arr[0];
            }

            var result = int.MinValue;

            for (var i = 0; i < arr.Length; i++)
            {
                var otherBalloons = arr.ToList();
                otherBalloons.RemoveAt(i);

                var currentBalloonCost = arr[i] * (i > 0 ? arr[i - 1] : 1) * (i + 1 < arr.Length ? arr[i + 1] : 1);
                var otherBalloonsCost = recursiveFunc(MakeKey(otherBalloons));

                result = Math.Max(result, currentBalloonCost + otherBalloonsCost);
            }

            return result;
        });

        return dp.GetOrCalculate(MakeKey(nums));
    }

    private static int[] ParseKey(string key) => key.Split(',').Select(str => Convert.ToInt32(str)).ToArray();

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
