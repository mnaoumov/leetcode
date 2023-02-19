using JetBrains.Annotations;

namespace LeetCode._0909_Snakes_and_Ladders;

/// <summary>
/// https://leetcode.com/submissions/detail/884076326/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int SnakesAndLadders(int[][] board)
    {
        var n = board.Length;
        var finishSquare = n * n;
        var processing = new HashSet<int>();

        var dp = new DynamicProgramming<int, int>((square, recursiveFunc) =>
        {
            const int impossible = -1;
            const int regularSquare = -1;

            if (square == finishSquare)
            {
                return 0;
            }

            processing.Add(square);

            var steps = int.MaxValue;

            foreach (var nextSquare in Enumerable.Range(square + 1, Math.Min(6, finishSquare - square)))
            {
                var row = n - 1 - (nextSquare - 1) / n;
                var column = (nextSquare - 1) % n;

                if ((n - 1 - row) % 2 == 1)
                {
                    column = n - 1 - column;
                }

                var followedNextSquare = board[row][column] == regularSquare ? nextSquare : board[row][column];

                if (processing.Contains(followedNextSquare))
                {
                    continue;
                }

                var nextSquareSteps = recursiveFunc(followedNextSquare);

                if (nextSquareSteps != impossible)
                {
                    steps = Math.Min(steps, 1 + nextSquareSteps);
                }
            }

            processing.Remove(square);

            return steps == int.MaxValue ? impossible : steps;
        });

        return dp.GetOrCalculate(1);
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
