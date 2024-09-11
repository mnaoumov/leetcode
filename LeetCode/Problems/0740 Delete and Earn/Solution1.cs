namespace LeetCode.Problems._0740_Delete_and_Earn;

/// <summary>
/// https://leetcode.com/submissions/detail/924552758/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int DeleteAndEarn(int[] nums)
    {
        var counts = nums.GroupBy(num => num).ToDictionary(g => g.Key, g => g.Count());
        var uniqueNums = counts.Keys.OrderBy(num => num).ToArray();

        var dp = new DynamicProgramming<int, int>((index, recursiveFunc) =>
        {
            if (index == uniqueNums.Length)
            {
                return 0;
            }

            var num = uniqueNums[index];
            var numSum = num * counts[num];

            var hasNext = index + 1 < uniqueNums.Length && uniqueNums[index + 1] == num + 1;

            return !hasNext
                ? numSum + recursiveFunc(index + 1)
                : Math.Max(
                    numSum + recursiveFunc(index + 2),
                    recursiveFunc(index + 1)
                );
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
