namespace LeetCode.Problems._1730_Shortest_Path_to_Get_Food;

/// <summary>
/// https://leetcode.com/submissions/detail/1508982790/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int GetFood(char[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        const char you = '*';
        const char food = '#';
        const char obstacle = 'X';

        var queue = new Queue<Cell>();

        var visited = new bool[m, n];

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                switch (grid[row][column])
                {
                    case you:
                        queue.Enqueue(new Cell(row, column));
                        break;
                    case obstacle:
                        visited[row, column] = true;
                        break;
                }
            }
        }

        var ans = 0;

        var directions = new[]
        {
            new Cell(0, 1),
            new Cell(0, -1),
            new Cell(1, 0),
            new Cell(-1, 0)
        };

        while (queue.Count > 0)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var cell = queue.Dequeue();

                if (!cell.IsValid(m, n))
                {
                    continue;
                }

                if (visited[cell.Row, cell.Column])
                {
                    continue;
                }

                visited[cell.Row, cell.Column] = true;

                switch (grid[cell.Row][cell.Column])
                {
                    case food:
                        return ans;
                    case obstacle:
                        continue;
                }

                foreach (var direction in directions)
                {
                    queue.Enqueue(cell.Move(direction));
                }
            }

            ans++;
        }

        return -1;
    }

    private record Cell(int Row, int Column)
    {
        public bool IsValid(int rowCount, int columnCount) =>
            Row >= 0 && Row < rowCount && Column >= 0 && Column < columnCount;

        public Cell Move(Cell direction) => new(Row + direction.Row, Column + direction.Column);
    }
}
