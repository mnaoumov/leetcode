namespace LeetCode.Problems._1671_Minimum_Number_of_Removals_to_Make_Mountain_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1437738634/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinimumMountainRemovals(int[] nums)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int lastTaken, bool isIncreasing), int>((key, recursiveFunc) =>
        {
            var (index, lastTaken, isIncreasing) = key;

            if (index == n)
            {
                return isIncreasing ? n : 0;
            }

            var ans = 1 + recursiveFunc((index + 1, lastTaken, isIncreasing));

            var num = nums[index];

            if (num == lastTaken)
            {
                return ans;
            }

            if (isIncreasing && num > lastTaken || !isIncreasing && num < lastTaken)
            {
                ans = Math.Min(ans, recursiveFunc((index + 1, num, isIncreasing)));
            }

            if (isIncreasing && num < lastTaken)
            {
                ans = Math.Min(ans, recursiveFunc((index + 1, num, false)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, int.MinValue, true));
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
