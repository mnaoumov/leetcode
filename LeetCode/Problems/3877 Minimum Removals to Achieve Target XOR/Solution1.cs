namespace LeetCode.Problems._3877_Minimum_Removals_to_Achieve_Target_XOR;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-494/problems/minimum-removals-to-achieve-target-xor/submissions/1955281457/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinRemovals(int[] nums, int target)
    {
        var n = nums.Length;
        var totalXor = nums.Aggregate((a, b) => a ^ b);
        const int impossible = int.MaxValue;

        var dp = new DynamicProgramming<(int index, int xor), int>((key, getOrCalculate) =>
        {
            var (index, xor) = key;

            if (xor == 0)
            {
                return 0;
            }

            if (index == n)
            {
                return impossible;
            }

            var ans2 = getOrCalculate((index + 1, xor));
            var subResult = getOrCalculate((index + 1, xor ^ nums[index]));

            if (subResult != impossible)
            {
                ans2 = Math.Min(ans2, subResult + 1);
            }

            return ans2;
        });

        var ans = dp.GetOrCalculate((0, totalXor ^ target));

        if (ans == impossible)
        {
            ans = -1;
        }

        return ans;
    }

    private sealed class DynamicProgramming<TKey, TValue> where TKey : notnull
    {
        private readonly Func<TKey, Func<TKey, TValue>, TValue> _func;
        private readonly Dictionary<TKey, TValue> _cache = new();

        public DynamicProgramming(Func<TKey, Func<TKey, TValue>, TValue> func) => _func = func;

        public TValue GetOrCalculate(TKey key) => !_cache.TryGetValue(key, out var value)
            ? _cache[key] = _func(key, GetOrCalculate)
            : value;
    }
}
