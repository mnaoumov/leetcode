namespace LeetCode.Problems._1391_Check_if_There_is_a_Valid_Path_in_a_Grid;

/// <summary>
/// https://leetcode.com/problems/check-if-there-is-a-valid-path-in-a-grid/submissions/1989023276/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool HasValidPath(int[][] grid)
    {
        var streetSidesMap = new Dictionary<int, Side[]>
        {
            [1] = new[] { Side.Left, Side.Right },
            [2] = new[] { Side.Up, Side.Down },
            [3] = new[] { Side.Left, Side.Down },
            [4] = new[] { Side.Right, Side.Down },
            [5] = new[] { Side.Left, Side.Up },
            [6] = new[] { Side.Right, Side.Up },
        };

        var m = grid.Length;
        var n = grid[0].Length;
        var startPoint = new Point(0, 0);
        var endPoint = new Point(n - 1, m - 1);

        foreach (var side in Enum.GetValues<Side>())
        {
            var point = startPoint;
            var comingSide = side;
            var visited = new HashSet<Point>();

            while (true)
            {
                if (!point.IsValid(n, m))
                {
                    break;
                }

                if (!visited.Add(point))
                {
                    break;
                }

                var sides = streetSidesMap[grid[point.Y][point.X]];

                if (!sides.Contains(comingSide))
                {
                    break;
                }

                if (point == endPoint)
                {
                    return true;
                }

                var otherSide = sides.Except(new[] { comingSide }).First();
                point = point.Move(otherSide);
                comingSide = Reverse(otherSide);
            }
        }

        return false;
    }

    private static Side Reverse(Side side) =>
        side switch
        {
            Side.Left => Side.Right,
            Side.Right => Side.Left,
            Side.Up => Side.Down,
            Side.Down => Side.Up,
            _ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
        };

    private sealed record Point(int X, int Y)
    {
        public Point Move(Side side)
        {
            var deltaX = 0;
            var deltaY = 0;

            switch (side)
            {
                case Side.Left:
                    deltaX = -1;
                    break;
                case Side.Right:
                    deltaX = 1;
                    break;
                case Side.Up:
                    deltaY = -1;
                    break;
                case Side.Down:
                    deltaY = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(side), side, null);
            }

            return new Point(X + deltaX, Y + deltaY);
        }

        public bool IsValid(int m, int n) => 0 <= X && X < m && 0 <= Y && Y < n;
    }

    private enum Side
    {
        Left,
        Right,
        Up,
        Down
    }
}
