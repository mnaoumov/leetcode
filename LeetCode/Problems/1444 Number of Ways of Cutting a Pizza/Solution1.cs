using JetBrains.Annotations;

namespace LeetCode.Problems._1444_Number_of_Ways_of_Cutting_a_Pizza;

/// <summary>
/// https://leetcode.com/submissions/detail/925154002/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int Ways(string[] pizza, int k)
    {
        var rows = pizza.Length;
        var columns = pizza[0].Length;
        const char apple = 'A';

        var appleCountsDp = new DynamicProgramming<(int row, int column), int>((key, recursiveFunc) =>
        {
            var (row, column) = key;

            if (row >= rows || column >= columns)
            {
                return 0;
            }

            return (pizza[row][column] == apple ? 1 : 0)
                   + recursiveFunc((row + 1, column))
                   + recursiveFunc((row, column + 1))
                   - recursiveFunc((row + 1, column + 1));

        });

        var dp = new DynamicProgramming<(int row, int column, int peopleCount), int>((key, recursiveFunc) =>
        {
            var (row, column, peopleCount) = key;
            const int modulo = 1_000_000_007;

            if (row >= rows || column >= columns)
            {
                return 0;
            }

            if (appleCountsDp.GetOrCalculate((row, column)) < peopleCount)
            {
                return 0;
            }

            if (peopleCount == 1)
            {
                return 1;
            }

            var result = 0;

            for (var cutRow = row; cutRow < rows; cutRow++)
            {
                if (appleCountsDp.GetOrCalculate((cutRow, column)) > appleCountsDp.GetOrCalculate((cutRow + 1, column)))
                {
                    result = (result + recursiveFunc((cutRow + 1, column, peopleCount - 1))) % modulo;
                }
            }

            for (var cutColumn = column; cutColumn < columns; cutColumn++)
            {
                if (appleCountsDp.GetOrCalculate((row, cutColumn)) > appleCountsDp.GetOrCalculate((row, cutColumn + 1)))
                {
                    result = (result + recursiveFunc((row, cutColumn + 1, peopleCount - 1))) % modulo;
                }
            }

            return result;
        });

        return dp.GetOrCalculate((0, 0, k));
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
