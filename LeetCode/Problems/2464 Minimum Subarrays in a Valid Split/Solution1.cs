using JetBrains.Annotations;

namespace LeetCode._2464_Minimum_Subarrays_in_a_Valid_Split;

/// <summary>
/// https://leetcode.com/submissions/detail/875908186/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int ValidSubarraySplit(int[] nums)
    {
        const int impossible = -1;
        var dp = new DynamicProgramming<int, int>((prefixLength, recursiveFunc) =>
        {
            if (prefixLength == 0)
            {
                return 0;
            }

            var result = int.MaxValue;

            for (var j = 0; j < prefixLength; j++)
            {
                if (Gcd(nums[prefixLength - 1], nums[j]) == 1)
                {
                    continue;
                }

                var previousResult = recursiveFunc(j);

                if (previousResult != impossible)
                {
                    result = Math.Min(result, previousResult + 1);
                }
            }

            return result == int.MaxValue ? impossible : result;
        });

        return dp.GetOrCalculate(nums.Length);
    }

    private static int Gcd(int a, int b)
    {
        while (b > 0)
        {
            (a, b) = (b, a % b);
        }

        return a;
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
