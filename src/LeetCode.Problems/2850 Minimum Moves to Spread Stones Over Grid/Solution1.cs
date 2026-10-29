namespace LeetCode.Problems._2850_Minimum_Moves_to_Spread_Stones_Over_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-362/submissions/detail/1045236728/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumMoves(int[][] grid)
    {
        var queue = new Queue<int[][]>();
        queue.Enqueue(grid);
        const int size = 3;
        const string desiredKey = "111111111";
        var seenKeys = new HashSet<string>();

        var directions = new (int dRow, int dColumn)[] { (1, 0), (-1, 0), (0, 1), (0, -1) };

        var ans = 0;

        while (true)
        {
            var count = queue.Count;

            for (var i = 0; i < count; i++)
            {
                var state = queue.Dequeue();
                var key = string.Concat(Enumerable.Range(0, size)
                    .SelectMany(_ => Enumerable.Range(0, size), (row, column) => state[row][column]));

                if (desiredKey == key)
                {
                    return ans;
                }

                if (!seenKeys.Add(key))
                {
                    continue;
                }

                for (var row = 0; row < size; row++)
                {
                    for (var column = 0; column < size; column++)
                    {
                        if (state[row][column] < 2)
                        {
                            continue;
                        }

                        foreach (var (dRow, dColumn) in directions)
                        {
                            var nextRow = row + dRow;
                            var nextColumn = column + dColumn;

                            if (nextRow < 0 || nextRow >= size || nextColumn < 0 || nextColumn >= size)
                            {
                                continue;
                            }

                            var nextState = state.Select(stateRow => stateRow.ToArray()).ToArray();
                            nextState[row][column]--;
                            nextState[nextRow][nextColumn]++;
                            queue.Enqueue(nextState);
                        }
                    }
                }
            }

            ans++;
        }
    }
}
