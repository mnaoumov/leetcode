namespace LeetCode.Problems._2786_Visit_Array_Positions_to_Maximize_Score;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-109/submissions/detail/1001048966/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MaxScore(int[] nums, int x)
    {
        var dp = new DynamicProgramming<(int index, bool isEven), long>((key, recursiveFunc) =>
        {
            var (index, isEven) = key;

            if (index == nums.Length)
            {
                return 0;
            }

            var num = nums[index];
            var isNumEven = num % 2 == 0;
            var penalty = isNumEven == isEven ? 0 : x;

            return new[]
            {
                0,
                num - penalty + recursiveFunc((index + 1, isNumEven)),
                recursiveFunc((index + 1, isEven))
            }.Max();
        });

        return nums[0] + dp.GetOrCalculate((1, nums[0] % 2 == 0));
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
