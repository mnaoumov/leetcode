using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2542_Maximum_Subsequence_Score;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-96/submissions/detail/882466921/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long MaxScore(int[] nums1, int[] nums2, int k)
    {
        var n = nums1.Length;

        var dp =
            new DynamicProgramming<(int startIndex, int count, long previousSum1, int previousMin2),
                (long sum1, int min2, long result)>(
                (key, recursiveFunc) =>
                {
                    var (startIndex, count, previousSum1, previousMin2) = key;

                    if (count == 0)
                    {
                        return (previousSum1, previousMin2, previousSum1 * previousMin2);
                    }

                    if (startIndex + count > n)
                    {
                        return (0L, 0, long.MinValue);
                    }

                    var skipResult = recursiveFunc((startIndex + 1, count, previousSum1, previousMin2));
                    var takeResult = recursiveFunc((startIndex + 1, count - 1, previousSum1 + nums1[startIndex],
                        Math.Min(previousMin2, nums2[startIndex])));

                    return new[] { skipResult, takeResult }.MaxBy(x => x.result);
                });

        return dp.GetOrCalculate((0, k, 0, int.MaxValue)).result;
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
