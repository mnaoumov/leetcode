namespace LeetCode.Problems._0446_Arithmetic_Slices_II___Subsequence;

/// <summary>
/// https://leetcode.com/submissions/detail/856184264/
/// </summary>
[UsedImplicitly]
public class Solution6 : ISolution
{
    public int NumberOfArithmeticSlices(int[] nums)
    {
        var numIndicesMap = nums.Select((num, index) => (num, index)).ToLookup(p => p.num, p => p.index)
            .ToDictionary(g => g.Key, g => g.OrderBy(x => x).ToArray());

        var dp = new DynamicProgramming<(int num, int diff, int minIndex), int>((key, recursiveFunc) =>
        {
            var (num, diff, minIndex) = key;

            switch (diff)
            {
                case >= 0 when num > int.MaxValue - diff:
                case < 0 when num < int.MinValue - diff:
                    return 0;
            }

            var nextNum = num + diff;

            if (!numIndicesMap.TryGetValue(nextNum, out var indices))
            {
                return 0;
            }

            var position = Array.BinarySearch(indices, minIndex);

            if (position < 0)
            {
                position = ~position;
            }

            return indices.Skip(position).Sum(index => 1 + recursiveFunc((nextNum, diff, index + 1)));
        });

        var result = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            for (var j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] < 0 && nums[j] > nums[i] + int.MaxValue)
                {
                    continue;
                }

                if (nums[i] >= 0 && nums[j] < nums[i] + int.MinValue)
                {
                    continue;
                }

                var diff = nums[j] - nums[i];

                result += dp.GetOrCalculate((nums[j], diff, j + 1));
            }
        }

        return result;
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
