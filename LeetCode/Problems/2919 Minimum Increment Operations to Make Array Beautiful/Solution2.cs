namespace LeetCode.Problems._2919_Minimum_Increment_Operations_to_Make_Array_Beautiful;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-369/submissions/detail/1086504403/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinIncrementOperations(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<(int index, int incrementedTripletIndex), long>((key, recursiveFunc) =>
        {
            var (index, incrementedTripletIndex) = key;

            if (index > n - 3)
            {
                return 0;
            }

            var num0 = incrementedTripletIndex == 1 ? k : nums[index];
            var num1 = incrementedTripletIndex == 2 ? k : nums[index + 1];
            var num2 = nums[index + 2];

            var max = new[] { num0, num1, num2 }.Max();
            var nextIncrementedTripletIndex = incrementedTripletIndex == 2 ? 1 : 0;

            if (max >= k)
            {
                return recursiveFunc((index + 1, nextIncrementedTripletIndex));
            }

            var ans = k - num0 + recursiveFunc((index + 1, 0));
            ans = Math.Min(ans, k - num1 + recursiveFunc((index + 1, 1)));
            ans = Math.Min(ans, k - num2 + recursiveFunc((index + 1, 2)));

            return ans;
        });

        return dp.GetOrCalculate((0, 0));
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
