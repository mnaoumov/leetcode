using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._3283_Maximum_Number_of_Moves_to_Kill_All_Pawns;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-414/submissions/detail/1382777654/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxMoves(int kx, int ky, int[][] positions)
    {
        var n = positions.Length;
        const int boardSize = 50;

        var knightMoves = new[]
        {
            new Position(2, 1),
            new Position(1, 2),
            new Position(-2, 1),
            new Position(-1, 2),
            new Position(2, -1),
            new Position(1, -2),
            new Position(-2, -1),
            new Position(-1, -2)
        };

        var dp = new DynamicProgramming<(Position knightPosition, bool isAlice, string capturedPawnsIndicesStr), int>((key, recursiveFunc) =>
        {
            var (knightPosition, isAlice, capturedPawnsIndicesStr) = key;
            var capturedPawnsIndices = capturedPawnsIndicesStr.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            if (capturedPawnsIndices.Count == n)
            {
                return 0;
            }

            var ans = isAlice ? int.MinValue : int.MaxValue;

            for (var i = 0; i < n; i++)
            {
                if (!capturedPawnsIndices.Add(i))
                {
                    continue;
                }

                capturedPawnsIndices.Add(i);
                var newCapturedPawnsIndicesStr = string.Join(' ', capturedPawnsIndices.OrderBy(x => x));

                var movesToPawn = 0;
                var queue = new Queue<Position>();
                queue.Enqueue(knightPosition);
                var visited = new HashSet<Position>();
                var pawnPosition = new Position(positions[i][0], positions[i][1]);

                while (true)
                {
                    var found = false;
                    var count = queue.Count;

                    for (var j = 0; j < count; j++)
                    {
                        var position = queue.Dequeue();
                        if (position == pawnPosition)
                        {
                            found = true;
                            break;
                        }

                        if (!visited.Add(position))
                        {
                            continue;
                        }

                        foreach (var knightMove in knightMoves)
                        {
                            var newPosition = new Position(position.X + knightMove.X, position.Y + knightMove.Y);
                            if (newPosition.X < 0 || newPosition.X >= boardSize || newPosition.Y < 0 || newPosition.Y >= boardSize)
                            {
                                continue;
                            }

                            queue.Enqueue(newPosition);
                        }
                    }

                    if (found)
                    {
                        break;
                    }

                    movesToPawn++;
                }

                var nextMovesCount = recursiveFunc((pawnPosition, !isAlice, newCapturedPawnsIndicesStr));
                ans = isAlice ? Math.Max(ans, movesToPawn + nextMovesCount) : Math.Min(ans, movesToPawn + nextMovesCount);
                capturedPawnsIndices.Remove(i);
            }

            return ans;
        });

        return dp.GetOrCalculate((new Position(kx, ky), true, ""));
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

    private record Position(int X, int Y);
}
