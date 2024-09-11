using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._1289_Minimum_Falling_Path_Sum_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1242190522/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MinFallingPathSum(int[][] grid)
    {
        var n = grid.Length;
        var dp = new DynamicProgramming<(int row, int previousColumn), int>((key, recursiveFunc) =>
        {
            var (row, previousColumn) = key;

            if (row == n)
            {
                return 0;
            }

            var ans = int.MaxValue;

            for (var column = 0; column < n; column++)
            {
                if (column == previousColumn)
                {
                    continue;
                }
                
                var sum = grid[row][column] + recursiveFunc((row + 1, column));
                ans = Math.Min(ans, sum);
            }
            
            return ans;
        });

        return dp.GetOrCalculate((0, -1));
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
