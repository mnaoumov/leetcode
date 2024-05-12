using JetBrains.Annotations;

namespace LeetCode._2560_House_Robber_IV;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-331/submissions/detail/891707732/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int MinCapability(int[] nums, int k)
    {
        var dp = new DynamicProgramming<(int index, int housesToRobCount), int>((key, recursiveFunc) =>
        {
            var (index, housesToRobCount) = key;

            if (housesToRobCount == 0)
            {
                return 0;
            }

            if (index + housesToRobCount > nums.Length)
            {
                return int.MaxValue;
            }

            return Math.Min(
                recursiveFunc((index + 1, housesToRobCount)),
                Math.Max(nums[index], recursiveFunc((index + 2, housesToRobCount - 1)))
            );
        });

        return dp.GetOrCalculate((0, k));
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
