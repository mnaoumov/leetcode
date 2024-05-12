using JetBrains.Annotations;

namespace LeetCode.Problems._2369_Check_if_There_is_a_Valid_Partition_For_The_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1019721035/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool ValidPartition(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<int, bool>((index, recursiveFunc) =>
        {
            if (index == n)
            {
                return true;
            }

            return index + 1 < n && nums[index + 1] == nums[index] && recursiveFunc(index + 2)
                   || index + 2 < n && nums[index + 1] == nums[index] && nums[index + 2] == nums[index + 1] &&
                   recursiveFunc(index + 3)
                   || index + 2 < n && nums[index + 1] == nums[index] + 1 && nums[index + 2] == nums[index + 1] + 1;
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
