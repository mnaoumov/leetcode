using JetBrains.Annotations;

namespace LeetCode.Problems._2061_Number_of_Spaces_Cleaning_Robot_Cleaned;

/// <summary>
/// https://leetcode.com/submissions/detail/1259364874/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int NumberOfCleanRooms(int[][] room)
    {
        var m = room.Length;
        var n = room[0].Length;
        const int @object = 1;

        var row = 0;
        var column = 0;
        var direction = Direction.Right;

        var visited = new HashSet<(int row, int column, Direction direction)>();
        var cleanRooms = new HashSet<(int row, int column)>();

        while (visited.Add((row, column, direction)))
        {
            cleanRooms.Add((row, column));
            var nextRow = row + direction.DeltaRow;
            var nextColumn = column + direction.DeltaColumn;

            if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n ||
                room[nextRow][nextColumn] == @object)
            {
                direction = direction.TurnClockwise();
            }
            else
            {
                row = nextRow;
                column = nextColumn;
            }
        }

        return cleanRooms.Count;
    }

    private abstract class Direction
    {
        private Direction()
        {
        }

        private static readonly Direction Up = new DirectionUp();
        public static readonly Direction Right = new DirectionRight();
        private static readonly Direction Down = new DirectionDown();
        private static readonly Direction Left = new DirectionLeft();

        public abstract int DeltaRow { get; }
        public abstract int DeltaColumn { get; }
        public abstract Direction TurnClockwise();

        private class DirectionUp : Direction
        {
            public override int DeltaRow => -1;
            public override int DeltaColumn => 0;
            public override Direction TurnClockwise() => Right;
        }

        private class DirectionRight : Direction
        {
            public override int DeltaRow => 0;
            public override int DeltaColumn => 1;
            public override Direction TurnClockwise() => Down;
        }

        private class DirectionDown : Direction
        {
            public override int DeltaRow => 1;
            public override int DeltaColumn => 0;
            public override Direction TurnClockwise() => Left;
        }

        private class DirectionLeft : Direction
        {
            public override int DeltaRow => 0;
            public override int DeltaColumn => -1;
            public override Direction TurnClockwise() => Up;
        }
    }
}
