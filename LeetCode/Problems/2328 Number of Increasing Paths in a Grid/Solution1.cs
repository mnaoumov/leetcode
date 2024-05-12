using JetBrains.Annotations;

namespace LeetCode.Problems._2328_Number_of_Increasing_Paths_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/973672073/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountPaths(int[][] grid)
    {
        const int modulo = 1_000_000_007;

        var m = grid.Length;
        var n = grid[0].Length;

        var directions = new[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var dp = new DynamicProgramming<(int row, int column), int>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            var ans = 1;

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;

                if (nextRow >= 0 && nextRow < m && nextColumn >= 0 && nextColumn < n && grid[nextRow][nextColumn] > grid[row][column])
                {
                    ans = ModSum(modulo, ans, recursiveFunc((nextRow, nextColumn)));
                }
            }

            return ans;
        });

        return ModSum(modulo,
            Enumerable.Range(0, m)
                .SelectMany(_ => Enumerable.Range(0, n), (row, column) => dp.GetOrCalculate((row, column))));
    }

    private static int ModSum(int modulo, IEnumerable<int> nums) => nums.Aggregate(0, (cur, num) => (cur + num) % modulo);
    private static int ModSum(int modulo, params int[] nums) => ModSum(modulo, nums.AsEnumerable());

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
