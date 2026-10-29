namespace LeetCode.Problems._0489_Robot_Room_Cleaner;

public class Robot
{
    private const int AccessibleCell = 1;
    private readonly int[][] _room;
    private int _row;
    private int _column;
    private (int dRow, int dColumn) _direction;
    private readonly bool[,] _cleanRooms;
    private int _dirtyRoomsCount;

    public Robot(int[][] room, int row, int column)
    {
        _room = room;
        _row = row;
        _column = column;
        _direction = (-1, 0);
        var m = _room.Length;
        var n = _room[0].Length;
        _cleanRooms = new bool[m, n];

        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (_room[i][j] == AccessibleCell)
                {
                    _dirtyRoomsCount++;
                }
            }
        }
    }

    public bool Move()
    {
        var nextRow = _row + _direction.dRow;
        var nextColumn = _column + _direction.dColumn;
        var m = _room.Length;
        var n = _room[0].Length;

        if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
        {
            return false;
        }

        if (_room[nextRow][nextColumn] != AccessibleCell)
        {
            return false;
        }

        _row = nextRow;
        _column = nextColumn;
        return true;
    }

    public void TurnLeft() => _direction = (-_direction.dColumn, _direction.dRow);
    public void TurnRight() => _direction = (_direction.dColumn, -_direction.dRow);

    public void Clean()
    {
        if (!_cleanRooms[_row, _column])
        {
            _dirtyRoomsCount--;
        }

        _cleanRooms[_row, _column] = true;
    }

    public bool VisitedAllRooms => _dirtyRoomsCount == 0;
}