using JetBrains.Annotations;

namespace LeetCode._1197_Minimum_Knight_Moves;

/// <summary>
/// https://leetcode.com/submissions/detail/1087697360/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinKnightMoves(int x, int y)
    {
        var queue = new Queue<(int row, int column, int steps)>();
        queue.Enqueue((0, 0, 0));

        var visited = new HashSet<(int row, int column)>();
        var moves = new List<(int dRow, int dColumn)>();

        foreach (var i in new[] { -1, 1 })
        {
            foreach (var j in new[] { -2, 2 })
            {
                moves.Add((i, j));
                moves.Add((j, i));
            }
        }

        while (true)
        {
            var (row, column, steps) = queue.Dequeue();

            if (!visited.Add((row, column)))
            {
                continue;
            }

            if (row == x && column == y)
            {
                return steps;
            }

            foreach (var (dRow, dColumn) in moves)
            {
                queue.Enqueue((row + dRow, column + dColumn, steps + 1));
            }
        }
    }
}
