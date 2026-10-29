namespace LeetCode.Problems._2371_Minimize_Maximum_Value_in_a_Grid;

/// <summary>
/// https://leetcode.com/submissions/detail/1459672907/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[][] MinScore(int[][] grid)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var ans = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();
        var cellCountsByRows = new int[m];
        var cellCountsByColumns = new int[n];

        var pq = new PriorityQueue<(int row, int column), int>();

        for (var row = 0; row < m; row++)
        {
            for (var column = 0; column < n; column++)
            {
                pq.Enqueue((row, column), grid[row][column]);
            }
        }

        while (pq.Count > 0)
        {
            var (row, column) = pq.Dequeue();
            var value = Math.Max(cellCountsByRows[row], cellCountsByColumns[column]) + 1;
            ans[row][column] = value;
            cellCountsByRows[row]++;
            cellCountsByColumns[column]++;
        }

        return ans;
    }
}
