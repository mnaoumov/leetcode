using JetBrains.Annotations;

namespace LeetCode.Problems._0174_Dungeon_Game;

/// <summary>
/// https://leetcode.com/submissions/detail/882161846/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CalculateMinimumHP(int[][] dungeon)
    {
        var m = dungeon.Length;
        var n = dungeon[0].Length;

        var dp = new DynamicProgramming<(int row, int column), int>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            if (row == m || column == n)
            {
                return int.MinValue;
            }

            var roomValue = dungeon[row][column];

            if (row == m - 1 && column == n - 1)
            {
                return roomValue;
            }

            var maxNextPath = Math.Max(recursiveFunc((row + 1, column)), recursiveFunc((row, column + 1)));
            return roomValue + Math.Min(0, maxNextPath);
        });

        return 1 - Math.Min(0, dp.GetOrCalculate((0, 0)));
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
