using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1218_Longest_Arithmetic_Subsequence_of_Given_Difference;

/// <summary>
/// https://leetcode.com/submissions/detail/919893202/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int LongestSubsequence(int[] arr, int difference)
    {
        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == arr.Length)
            {
                return 0;
            }

            var result = 1;

            for (var j = index + 1; j < arr.Length; j++)
            {
                if (arr[j] == arr[index] + difference)
                {
                    result = Math.Max(result, 1 + recursiveFunc(j));
                }
            }

            return result;
        });

        return Enumerable.Range(0, arr.Length).Max(i => dp.GetOrCalculate(i));
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
