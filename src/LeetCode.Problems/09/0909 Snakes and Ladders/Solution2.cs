namespace LeetCode.Problems._0909_Snakes_and_Ladders;

/// <summary>
/// https://leetcode.com/submissions/detail/884092427/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SnakesAndLadders(int[][] board)
    {
        const int impossible = -1;
        const int regularSquare = -1;

        var n = board.Length;
        var finishSquare = n * n;
        var processing = new HashSet<int>();

        var queue = new Queue<(int square, int steps)>();
        queue.Enqueue((1, 0));

        while (queue.Count > 0)
        {
            var (square, steps) = queue.Dequeue();

            if (square == finishSquare)
            {
                return steps;
            }

            if (!processing.Add(square))
            {
                continue;
            }

            foreach (var nextSquare in Enumerable.Range(square + 1, Math.Min(6, finishSquare - square)))
            {
                var row = n - 1 - (nextSquare - 1) / n;
                var column = (nextSquare - 1) % n;

                if ((n - 1 - row) % 2 == 1)
                {
                    column = n - 1 - column;
                }

                var followedNextSquare = board[row][column] == regularSquare ? nextSquare : board[row][column];

                queue.Enqueue((followedNextSquare, steps + 1));
            }
        }

        return impossible;
    }
}
