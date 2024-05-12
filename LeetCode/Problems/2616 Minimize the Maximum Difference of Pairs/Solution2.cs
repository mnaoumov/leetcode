using JetBrains.Annotations;

namespace LeetCode._2616_Minimize_the_Maximum_Difference_of_Pairs;

/// <summary>
/// https://leetcode.com/submissions/detail/930526498/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int MinimizeMax(int[] nums, int p)
    {
        Array.Sort(nums);

        var dp = new DynamicProgramming<(int index, int pairsCount), int>((key, recursiveFunc) =>
        {
            var (index, pairsCount) = key;

            return index >= nums.Length - 1
                ? pairsCount == 0 ? 0 : int.MaxValue
                : Math.Min(
                    recursiveFunc((index + 1, pairsCount)),
                    Math.Max(nums[index + 1] - nums[index], recursiveFunc((index + 2, pairsCount - 1))));
        });

        return dp.GetOrCalculate((0, p));
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
