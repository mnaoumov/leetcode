using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0741_Cherry_Pickup;

/// <summary>
/// https://leetcode.com/submissions/detail/954151792/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int CherryPickup(int[][] grid)
    {
        var n = grid.Length;
        const int thorn = -1;
        const int cherry = 1;
        const int impossible = -1;

        var dp = new DynamicProgramming<(int row, int column, int direction, string takenCherriesStr), int>((key, recursiveFunc) =>
        {
            var (row, column, direction, takenCherriesStr) = key;

            if (row < 0 || column < 0 || row == n || column == n || grid[row][column] == thorn)
            {
                return impossible;
            }

            if (row == 0 && column == 0 && direction == -1)
            {
                return 0;
            }

            if (row == n - 1 && column == n - 1 && direction == 1)
            {
                return recursiveFunc((n - 1, n - 1, -1, takenCherriesStr));
            }

            var cherryKey = $"{row}-{column}";
            var takenCherries = takenCherriesStr.Split(',').ToHashSet();

            var cost = grid[row][column] == cherry && !takenCherries.Contains(cherryKey) ? 1 : 0;

            var nextTakenCherriesStr = cost == 1 && direction == 1
                ? takenCherriesStr == "" ? cherryKey : $"{takenCherriesStr},{cherryKey}"
                : takenCherriesStr;

            var ans = Math.Max(
                recursiveFunc((row + direction, column, direction, nextTakenCherriesStr)),
                recursiveFunc((row, column + direction, direction, nextTakenCherriesStr)));

            return ans == impossible ? impossible : ans + cost;
        });

        var ans2 = dp.GetOrCalculate((0, 0, 1, ""));
        return ans2 == impossible ? 0 : ans2;
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
