using JetBrains.Annotations;

namespace LeetCode.Problems._2547_Minimum_Cost_to_Split_an_Array;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-329/submissions/detail/882795913/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinCost(int[] nums, int k)
    {
        var n = nums.Length;

        var dp = new DynamicProgramming<int, int>((startingIndex, recursiveFunc) =>
        {
            if (startingIndex == nums.Length)
            {
                return 0;
            }

            var counts = new Dictionary<int, int>();
            var trimmedLength = 0;
            var result = long.MaxValue;

            for (var i = startingIndex; i < n; i++)
            {
                var num = nums[i];
                counts[num] = counts.GetValueOrDefault(num) + 1;

                switch (counts[num])
                {
                    case 2:
                        trimmedLength += 2;
                        break;
                    case > 1:
                        trimmedLength++;
                        break;
                }

                result = Math.Min(result, 0L + trimmedLength + k + recursiveFunc(i + 1));
            }

            // ReSharper disable once IntVariableOverflowInUncheckedContext
            return (int) result;
        });

        return dp.GetOrCalculate(0);
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
