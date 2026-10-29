namespace LeetCode.Problems._2556_Disconnect_Path_in_a_Binary_Matrix_by_at_Most_One_Flip;

/// <summary>
/// https://leetcode.com/submissions/detail/891663643/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsPossibleToCutPath(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;

        var queue = new Queue<(int row, int column)>();
        queue.Enqueue((0, 0));
        var step = 0;

        while (queue.Count > 0)
        {
            var stepOptionsCount = queue.Count;

            if (stepOptionsCount == 1 && step > 0)
            {
                return step != m + n - 2;
            }

            var nextCells = new HashSet<(int row, int column)>();

            for (var i = 0; i < stepOptionsCount; i++)
            {
                var (row, column) = queue.Dequeue();

                AddNextCell(row + 1, column);
                AddNextCell(row, column + 1);
            }

            step++;
            continue;

            void AddNextCell(int row, int column)
            {
                if (row < m && column < n && grid[row][column] == 1 && nextCells.Add((row, column)))
                {
                    queue.Enqueue((row, column));
                }
            }
        }

        return true;
    }
}
