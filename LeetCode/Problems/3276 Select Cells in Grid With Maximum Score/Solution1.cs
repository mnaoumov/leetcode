using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3276_Select_Cells_in_Grid_With_Maximum_Score;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-413/submissions/detail/1374813694/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MaxScore(IList<IList<int>> grid)
    {
        var n = grid.Count;

        var dp = new DynamicProgramming<(int row, string takenNumbersStr), int>((key, recursiveFunc) =>
        {
            var (row, takenNumbersStr) = key;

            if (row == n)
            {
                return 0;
            }

            var takenNumbers = takenNumbersStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToHashSet();

            var ans = 0;

            foreach (var cell in grid[row])
            {
                if (!takenNumbers.Add(cell))
                {
                    continue;
                }

                var newTakenNumberStr = string.Join(' ', takenNumbers.OrderBy(x => x));
                ans = Math.Max(ans, cell + recursiveFunc((row + 1, newTakenNumberStr)));
                takenNumbers.Remove(cell);
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
