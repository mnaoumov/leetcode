namespace LeetCode.Problems._3524_Find_X_Value_of_Array_I;

/// <summary>
/// https://leetcode.com/problems/find-x-value-of-array-i/submissions/2148761202/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long[] ResultArray(int[] nums, int k)
    {
        var n = nums.Length;

        for (var i = 0; i < n; i++)
        {
            nums[i] %= k;
        }

        var divisionMap = new Dictionary<(int product, int multiplier), List<int>>();

        for (var a = 0; a < k; a++)
        {
            for (var b = 0; b < k; b++)
            {
                var product = (a * b) % k;
                divisionMap.TryAdd((product, a), new List<int>());
                divisionMap[(product, a)].Add(b);
            }
        }


        var dp = new DynamicProgramming<(int lastIndex, int remainder), long>((key, getOrCalculate) =>
        {
            var (lastIndex, remainder) = key;

            var ans2 = 0L;

            if (nums[lastIndex] == remainder)
            {
                ans2++;
            }

            if (lastIndex > 0)
            {
                ans2 += divisionMap.GetValueOrDefault((remainder, nums[lastIndex]), new List<int>())
                    .Sum(previousRemainder => getOrCalculate((lastIndex - 1, previousRemainder)));
            }

            return ans2;
        });

        var ans = new long[k];

        for (var i = 0; i < n; i++)
        {
            for (var r = 0; r < k; r++)
            {
                ans[r] += dp.GetOrCalculate((i, r));
            }
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
