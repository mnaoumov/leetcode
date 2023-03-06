using JetBrains.Annotations;

namespace LeetCode._6310_Number_of_Ways_to_Earn_Points;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-335/submissions/detail/909300017/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int WaysToReachTarget(int target, int[][] types)
    {
        const int modulo = 1_000_000_007;

        var dp = new DynamicProgramming<(int typeIndex, int subTarget), int>((key, recursiveFunc) =>
        {
            var (typeIndex, subTarget) = key;

            if (typeIndex == types.Length)
            {
                return subTarget == 0 ? 1 : 0;
            }

            var type = types[typeIndex];
            var count = type[0];
            var marks = type[1];

            var maxCount = Math.Min(count, subTarget / marks);

            var result = 0;

            for (var i = 0; i <= maxCount; i++)
            {
                result = (result + recursiveFunc((typeIndex + 1, subTarget - i * marks))) % modulo;
            }

            return result;
        });

        return dp.GetOrCalculate((0, target));
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
