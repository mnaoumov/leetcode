namespace LeetCode.Problems._2503_Maximum_Number_of_Points_From_Grid_Queries;

/// <summary>
/// https://leetcode.com/submissions/detail/859270407/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] MaxPoints(int[][] grid, int[] queries)
    {
        var m = grid.Length;
        var n = grid[0].Length;
        var k = queries.Length;
        var orderedQueryIndices = queries.Select((query, index) => (query, index)).OrderBy(p => p.query).ToArray();
        var answer = new int[k];

        var visited = new bool[m, n];

        var nextQueue = new Queue<(int row, int column)>();
        nextQueue.Enqueue((0, 0));

        var deltas = new[] { (0, 1), (0, -1), (1, 0), (-1, 0) };
        var queryAnswer = 0;
        var minSkippedValue = int.MaxValue;

        foreach (var (query, index) in orderedQueryIndices)
        {
            if (minSkippedValue != int.MaxValue && query <= minSkippedValue)
            {
                answer[index] = queryAnswer;
                continue;
            }

            minSkippedValue = int.MaxValue;
            var queue = nextQueue;
            nextQueue = new Queue<(int row, int column)>();

            while (queue.Count > 0)
            {
                var (row, column) = queue.Dequeue();

                if (row < 0 || row >= m || column < 0 || column >= n)
                {
                    continue;
                }

                if (visited[row, column])
                {
                    continue;
                }

                var value = grid[row][column];

                if (value >= query)
                {
                    nextQueue.Enqueue((row, column));
                    minSkippedValue = Math.Min(minSkippedValue, value);
                    continue;
                }

                visited[row, column] = true;

                queryAnswer++;

                foreach (var (dRow, dColumn) in deltas)
                {
                    queue.Enqueue((row + dRow, column + dColumn));
                }
            }

            answer[index] = queryAnswer;
        }

        return answer;
    }
}
