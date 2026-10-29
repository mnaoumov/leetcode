namespace LeetCode.Problems._1926_Nearest_Exit_from_Entrance_in_Maze;

/// <summary>
/// https://leetcode.com/problems/nearest-exit-from-entrance-in-maze/submissions/847184891/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    private const char Wall = '+';
    private const int Impossible = -1;

    public int NearestExit(char[][] maze, int[] entrance)
    {
        var queue = new Queue<(int row, int column, int numberOfSteps)>();
        queue.Enqueue((entrance[0], entrance[1], 0));

        var m = maze.Length;
        var n = maze[0].Length;

        var visited = new bool[m, n];

        var deltas = new[]
            { (dRow: 1, dColumn: 0), (dRow: -1, dColumn: 0), (dRow: 0, dColumn: 1), (dRow: 0, dColumn: -1) };

        while (queue.Count > 0)
        {
            var (row, column, numberOfSteps) = queue.Dequeue();

            if (row < 0 || row >= m || column < 0 || column >= n)
            {
                continue;
            }

            if (visited[row, column])
            {
                continue;
            }

            if (maze[row][column] == Wall)
            {
                continue;
            }

            if (numberOfSteps > 0 && (row == 0 || row == m - 1 || column == 0 || column == n - 1))
            {
                return numberOfSteps;
            }

            visited[row, column] = true;

            foreach (var (dRow, dColumn) in deltas)
            {
                queue.Enqueue((row + dRow, column + dColumn, numberOfSteps + 1));
            }
        }

        return Impossible;
    }
}
