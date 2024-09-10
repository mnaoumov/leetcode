using JetBrains.Annotations;

namespace LeetCode.Problems._3283_Maximum_Number_of_Moves_to_Kill_All_Pawns;

/// <summary>
/// https://leetcode.com/submissions/detail/1382800084/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
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

        var queue = new Queue<(Position start, Position current)>();
        var initialKnightPosition = new Position(kx, ky);
        queue.Enqueue((initialKnightPosition, initialKnightPosition));

        var pawnPositions = positions.Select(position => new Position(position[0], position[1])).ToArray();
        var pawnPositionsSet = pawnPositions.ToHashSet();
        var visited = new HashSet<(Position start, Position end)>();

        foreach (var pawnPosition in pawnPositions)
        {
            queue.Enqueue((pawnPosition, pawnPosition));
        }

        var movesToPawnsCounts = new Dictionary<(Position start, Position end), int>();

        var movesToPawnCount = 0;

        while (movesToPawnsCounts.Count < (n + 1) * n)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var (start, current) = queue.Dequeue();

                if (!visited.Add((start, current)))
                {
                    continue;
                }

                if (pawnPositionsSet.Contains(current))
                {
                    movesToPawnsCounts[(start, current)] = movesToPawnCount;
                }

                foreach (var knightMove in knightMoves)
                {
                    var nextPosition = new Position(current.X + knightMove.X, current.Y + knightMove.Y);
                    if (nextPosition.X < 0 || nextPosition.X >= boardSize || nextPosition.Y < 0 || nextPosition.Y >= boardSize)
                    {
                        continue;
                    }

                    queue.Enqueue((start, nextPosition));
                }
            }

            movesToPawnCount++;
        }

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

                var nextMovesCount = recursiveFunc((pawnPositions[i], !isAlice, newCapturedPawnsIndicesStr));
                var movesToPawnCount2 = movesToPawnsCounts[(knightPosition, pawnPositions[i])];
                ans = isAlice ? Math.Max(ans, movesToPawnCount2 + nextMovesCount) : Math.Min(ans, movesToPawnCount2 + nextMovesCount);
                capturedPawnsIndices.Remove(i);
            }

            return ans;
        });

        return dp.GetOrCalculate((initialKnightPosition, true, ""));
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
