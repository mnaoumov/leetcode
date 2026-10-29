namespace LeetCode.Problems._3286_Find_a_Safe_Walk_Through_a_Grid;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-139/submissions/detail/1389927384/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool FindSafeWalk(IList<IList<int>> grid, int health)
    {
        var m = grid.Count;
        var n = grid[0].Count;
        var queue = new Queue<(int row, int column, int currentHealth)>();

        queue.Enqueue((0, 0, health));
        var maxHealthMap = new Dictionary<(int row, int column), int>();

        var directions = new (int dRow, int dColumn)[] { (-1, 0), (1, 0), (0, -1), (0, 1) };

        while (queue.Count > 0)
        {
            var (row, column, currentHealth) = queue.Dequeue();

            if (grid[row][column] == 1)
            {
                currentHealth--;
            }

            if (currentHealth == 0)
            {
                continue;
            }

            if (row == m - 1 && column == n - 1)
            {
                return true;
            }

            if (maxHealthMap.TryGetValue((row, column), out var maxHealth) && maxHealth >= currentHealth)
            {
                continue;
            }

            maxHealthMap[(row, column)] = currentHealth;

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;
                if (nextRow >= 0 && nextRow < m && nextColumn >= 0 && nextColumn < n)
                {
                    queue.Enqueue((nextRow, nextColumn, currentHealth));
                }
            }
        }

        return false;
    }
}
