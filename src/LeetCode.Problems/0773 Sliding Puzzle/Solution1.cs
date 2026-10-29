namespace LeetCode.Problems._0773_Sliding_Puzzle;

/// <summary>
/// https://leetcode.com/submissions/detail/1462108900/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SlidingPuzzle(int[][] board)
    {
        var queue = new Queue<Board>();
        queue.Enqueue(new Board(board));
        var visited = new HashSet<Board>();

        var ans = 0;
        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var boardObj = queue.Dequeue();

                if (!visited.Add(boardObj))
                {
                    continue;
                }

                if (boardObj.IsSolved())
                {
                    return ans;
                }

                foreach (var neighbour in boardObj.GetNeighbours())
                {
                    queue.Enqueue(neighbour);
                }
            }

            ans++;
        }

        return -1;
    }

    private class Board
    {
        private static readonly (int dRow, int dColumn)[] Directions = { (-1, 0), (1, 0), (0, -1), (0, 1) };

        private readonly int[][] _array;
        private readonly string _str;
        private readonly int _emptyRow;
        private readonly int _emptyColumn;

        public Board(int[][] array)
        {
            _array = array;
            _str = string.Join("", _array.Select(row => string.Join("", row)));

            for (var row = 0; row < array.Length; row++)
            {
                for (var column = 0; column < array[row].Length; column++)
                {
                    if (array[row][column] != 0)
                    {
                        continue;
                    }

                    _emptyRow = row;
                    _emptyColumn = column;
                    break;
                }
            }
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj is not Board other)
            {
                return false;
            }

            return ToString() == other.ToString();
        }

        public override int GetHashCode() => ToString().GetHashCode();

        public override string ToString() => _str;

        public bool IsSolved() => ToString() == "123450";
        public IEnumerable<Board> GetNeighbours()
        {
            foreach (var direction in Directions)
            {
                var newEmptyRow = _emptyRow + direction.dRow;
                var newEmptyColumn = _emptyColumn + direction.dColumn;

                if (newEmptyRow < 0 || newEmptyRow >= _array.Length || newEmptyColumn < 0 || newEmptyColumn >= _array[newEmptyRow].Length)
                {
                    continue;
                }

                var newArr = _array.Select(row => row.ToArray()).ToArray();
                newArr[_emptyRow][_emptyColumn] = newArr[newEmptyRow][newEmptyColumn];
                newArr[newEmptyRow][newEmptyColumn] = 0;
                yield return new Board(newArr);
            }
        }
    }
}
