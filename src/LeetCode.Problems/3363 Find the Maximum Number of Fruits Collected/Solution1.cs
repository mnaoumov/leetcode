using System.Collections.Immutable;

namespace LeetCode.Problems._3363_Find_the_Maximum_Number_of_Fruits_Collected;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-144/submissions/detail/1460903571/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int MaxCollectedFruits(int[][] fruits)
    {
        var n = fruits.Length;
        var exit = new Position(n - 1, n - 1);

        var kidMoves = new[]
        {
            new[]
            {
                new Position(1, 1),
                new Position(1, 0),
                new Position(0, 1)
            },
            new[]
            {
                new Position(1, -1),
                new Position(1, 0),
                new Position(1, 1)
            },
            new[]
            {
                new Position(-1, 1),
                new Position(0, 1),
                new Position(1, 1)
            }
        };

        var queue = new Queue<(Position[] kids, int turn, int collectedFruits, ImmutableHashSet<Position> collectedFruitPositions)>();
        queue.Enqueue((
            new[]
            {
                new Position(0, 0),
                new Position(0, n - 1),
                new Position(n - 1, 0)
            }, 0, 0, ImmutableHashSet<Position>.Empty));

        var ans = 0;

        while (queue.Count > 0)
        {
            var (kids, turn, collectedFruits, collectedFruitPositions) = queue.Dequeue();

            foreach (var kid in kids)
            {
                if (collectedFruitPositions.Contains(kid))
                {
                    continue;
                }

                collectedFruits += fruits[kid.Row][kid.Column];
                collectedFruitPositions = collectedFruitPositions.Add(kid);
            }

            if (turn == n - 1)
            {
                if (kids.All(kid => kid == exit))
                {
                    ans = Math.Max(ans, collectedFruits);
                }

                continue;
            }

            var allNewPositions = new Position[kids.Length][];

            for (var i = 0; i < kids.Length; i++)
            {
                allNewPositions[i] = kidMoves[i]
                    .Select(move => new Position(kids[i].Row + move.Row, kids[i].Column + move.Column))
                    .Where(p => p.IsValid(n)).ToArray();
            }

            foreach (var newKids in GetAllCombinations(allNewPositions))
            {
                queue.Enqueue((newKids, turn + 1, collectedFruits, collectedFruitPositions));
            }
        }

        return ans;
    }

    private static IEnumerable<T[]> GetAllCombinations<T>(T[][] arrays, int index = 0)
    {
        if (index >= arrays.Length)
        {
            yield return Array.Empty<T>();
            yield break;
        }

        foreach (var subCombination in GetAllCombinations(arrays, index + 1))
        {
            var list = subCombination.Prepend(default!).ToArray();
            foreach (var item in arrays[index])
            {
                list[0] = item;
                yield return list.ToArray();
            }
        }
    }

    private record Position(int Row, int Column)
    {
        public bool IsValid(int n) => 0 <= Row && Row < n && 0 <= Column && Column < n;
    }
}
