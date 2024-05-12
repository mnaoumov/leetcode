using JetBrains.Annotations;

namespace LeetCode.Problems._2945_Find_Maximum_Non_decreasing_Array_Length;

/// <summary>
/// https://leetcode.com/submissions/detail/1107822947/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution5 : ISolution
{
    public int FindMaximumLength(int[] nums)
    {
        var n = nums.Length;
        var prefixSums = new long[n + 1];

        for (var i = 0; i < n; i++)
        {
            prefixSums[i + 1] = prefixSums[i] + nums[i];
        }

        var dp = new DynamicProgramming<int, (int length, long lastNum)>((length, recursiveFunc) =>
        {
            if (length == 0)
            {
                return (0, 0);
            }

            var sum = 0L;
            var (prevLength, lastNum2) = recursiveFunc(length - 1);
            var ans = (length: prevLength, lastNum: lastNum2 + nums[length - 1]);

            for (var j = length - 1; j >= 0; j--)
            {
                sum += nums[j];
                var (subLength, lastNum) = recursiveFunc(j);

                if (subLength + 1 < ans.length)
                {
                    break;
                }

                if (sum >= lastNum && sum <= ans.lastNum)
                {
                    ans = (subLength + 1, sum);
                }
            }

            return ans;
        });

        return dp.GetOrCalculate(n).length;
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
