namespace LeetCode.Problems._1263_Minimum_Moves_to_Move_a_Box_to_Their_Target_Location;

/// <summary>
/// https://leetcode.com/submissions/detail/969874972/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinPushBox(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var player = Coordinate.Unset;
        var box = Coordinate.Unset;
        var target = Coordinate.Unset;

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                var coordinate = new Coordinate(i, j);

                switch (grid[i][j])
                {
                    case Symbol.Player:
                        player = coordinate;
                        break;
                    case Symbol.Box:
                        box = coordinate;
                        break;
                    case Symbol.Target:
                        target = coordinate;
                        break;
                }
            }
        }

        var minBoxMoves = new Dictionary<(Coordinate player, Coordinate box), int>();

        var queue = new Queue<(Coordinate player, Coordinate box, int boxMoves)>();
        queue.Enqueue((player, box, 0));

        var ans = int.MaxValue;

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                (player, box, var boxesMoves) = queue.Dequeue();


                if (minBoxMoves.TryGetValue((player,box), out var previousBoxMoves) && previousBoxMoves <= boxesMoves)
                {
                    continue;
                }

                minBoxMoves[(player, box)] = boxesMoves;

                if (box == target)
                {
                    ans = Math.Min(ans, boxesMoves);
                    continue;
                }

                foreach (var direction in Coordinate.Directions)
                {
                    var nextPlayer = player.Move(direction);

                    if (nextPlayer == box)
                    {
                        var nextBox = box.Move(direction);

                        if (CanMove(nextBox))
                        {
                            queue.Enqueue((box, nextBox, boxesMoves + 1));
                        }
                    }
                    else if (CanMove(nextPlayer))
                    {
                        queue.Enqueue((nextPlayer, box, boxesMoves));
                    }
                }
            }
        }

        return ans == int.MaxValue ? -1 : ans;

        bool CanMove(Coordinate coordinate) =>
            coordinate.Row >= 0 && coordinate.Row < m && coordinate.Column >= 0 && coordinate.Column < n &&
            grid[coordinate.Row][coordinate.Column] != Symbol.Wall;
    }

    private record Coordinate(int Row, int Column)
    {
        public static readonly Coordinate Unset = new(-1, -1);

        public static readonly Coordinate[] Directions =
        {
            new(1, 0),
            new(-1, 0),
            new(0, 1),
            new(0, -1)
        };

        public Coordinate Move(Coordinate direction) => new(Row + direction.Row, Column + direction.Column);
    }

    private static class Symbol
    {
        public const char Player = 'S';
        public const char Box = 'B';
        public const char Target = 'T';
        public const char Wall = '#';
    }
}
