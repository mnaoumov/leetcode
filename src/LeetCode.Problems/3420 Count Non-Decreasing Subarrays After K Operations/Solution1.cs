namespace LeetCode.Problems._3420_Count_Non_Decreasing_Subarrays_After_K_Operations;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-432/submissions/detail/1505701606/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long CountNonDecreasingSubarrays(int[] nums, int k)
    {
        var n = nums.Length;
        const int noValue = int.MinValue;

        var dp = new DynamicProgramming<(int index, int operationsLeft, int previousValue), long>((key, recursiveFunc) =>
        {
            var (index, operationsLeft, previousValue) = key;

            if (index == n)
            {
                return 0;
            }

            var value = nums[index];

            var operationsNeeded = 0 switch
            {
                _ when previousValue == noValue => 0,
                _ when value >= previousValue => 0,
                _ => previousValue - value
            };

            return operationsNeeded <= operationsLeft
                ? 1 + recursiveFunc((index + 1, operationsLeft - operationsNeeded, Math.Max(value, previousValue)))
                : 0;
        });

        return Enumerable.Range(0, n).Select(index => dp.GetOrCalculate((index, k, noValue))).Sum();
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
