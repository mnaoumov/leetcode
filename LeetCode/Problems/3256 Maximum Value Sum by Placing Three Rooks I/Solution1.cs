using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3256_Maximum_Value_Sum_by_Placing_Three_Rooks_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-137/submissions/detail/1359163618/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public long MaximumValueSum(int[][] board)
    {
        var m = board.Length;
        var n = board[0].Length;

        var dp = new DynamicProgramming<(int row, string usedColumnsStr), long>((key, recursiveFunc) =>
        {
            var (row, usedColumnsStr) = key;
            var usedColumns = usedColumnsStr.Split(",", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            if (usedColumns.Count == 3)
            {
                return 0;
            }

            var ans = row < usedColumns.Count + m - 3 ? recursiveFunc((row + 1, usedColumnsStr)) : long.MinValue;

            var maxColumnsPq = new PriorityQueue<int, int>();

            for (var column = 0; column < n; column++)
            {
                if (usedColumns.Contains(column))
                {
                    continue;
                }

                var priority = board[row][column];
                maxColumnsPq.Enqueue(column, priority);
                if (maxColumnsPq.Count + usedColumns.Count > 3)
                {
                    maxColumnsPq.Dequeue();
                }
            }

            while (maxColumnsPq.Count > 0)
            {
                var column = maxColumnsPq.Dequeue();
                var nextUsedColumnsStr = string.Join(",", usedColumns.Append(column).OrderBy(c => c));
                ans = Math.Max(ans, board[row][column] + recursiveFunc((row + 1, nextUsedColumnsStr)));
            }

            return ans;
        });

        return dp.GetOrCalculate((0, ""));
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
