using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2871_Split_Array_Into_Maximum_Number_of_Subarrays;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-114/submissions/detail/1063164004/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MaxSubarrays(int[] nums)
    {
        var dp = new DynamicProgramming<(int l, int r), (int splitCount, long minSumOfScores)>((key, recursiveFunc) =>
        {
            var (l, r) = key;

            if (l > r)
            {
                return (0, 0);
            }

            var score = int.MaxValue;
            var ans = (splitCount: 0, minSumOfScores: long.MaxValue);

            for (var i = l; i <= r; i++)
            {
                var num = nums[i];

                score &= num;
                var (splitCount, minSumOfScores) = recursiveFunc((i + 1, r));

                var sumOfScores = score + minSumOfScores;

                if (sumOfScores > ans.minSumOfScores)
                {
                    continue;
                }

                if (sumOfScores < ans.minSumOfScores)
                {
                    ans = (splitCount + 1, sumOfScores);
                }
                else
                {
                    ans.splitCount = Math.Max(ans.splitCount, splitCount + 1);
                }
            }


            return ans;
        });

        return dp.GetOrCalculate((0, nums.Length - 1)).splitCount;
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
