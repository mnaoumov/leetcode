using JetBrains.Annotations;

namespace LeetCode._2786_Visit_Array_Positions_to_Maximize_Score;

/// <summary>
/// https://leetcode.com/submissions/detail/1001015816/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaxScore(int[] nums, int x)
    {
        var dp = new DynamicProgramming<int, long>((i, recursiveFunc) =>
        {
            var nextScore = 0L;

            for (var j = i + 1; j < nums.Length; j++)
            {
                var penalty = (nums[j] - nums[i]) % 2 == 0 ? 0 : x;
                nextScore = Math.Max(nextScore, recursiveFunc(j) - penalty);
            }

            return nums[i] + nextScore;
        });

        return dp.GetOrCalculate(0);
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
