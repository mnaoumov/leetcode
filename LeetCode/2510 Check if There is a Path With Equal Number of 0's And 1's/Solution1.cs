using JetBrains.Annotations;

namespace LeetCode._2510_Check_if_There_is_a_Path_With_Equal_Number_of_0_s_And_1_s;

/// <summary>
/// https://leetcode.com/submissions/detail/869932348/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsThereAPath(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var dp = new DynamicProgramming<(int row, int column, int differenceZeroOneCounts), bool>((key, recursiveFunc) =>
        {
            var (row, column, differenceZeroOneCounts) = key;

            if (row >= m || column >= n)
            {
                return false;
            }

            var nextDifference = differenceZeroOneCounts + (grid[row][column] == 0 ? -1 : 1);

            if (row == m - 1 && column == n - 1)
            {
                return nextDifference == 0;
            }

            return recursiveFunc((row + 1, column, nextDifference)) || recursiveFunc((row, column + 1, nextDifference));
        });

        return dp.GetOrCalculate((0, 0, 0));
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
