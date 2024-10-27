namespace LeetCode.Problems._2664_The_Knight_s_Tour;

/// <summary>
/// https://leetcode.com/submissions/detail/1431067592/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] TourOfKnight(int m, int n, int r, int c)
    {
        const int unset = -1;
        var ans = Enumerable.Range(0, m).Select(_ => Enumerable.Repeat(unset, n).ToArray()).ToArray();
        var directions = new[]
        {
            (dRow: 1, dColumn: 2),
            (dRow: 2, dColumn: 1),
            (dRow: 1, dColumn: -2),
            (dRow: 2, dColumn: -1),
            (dRow: -1, dColumn: 2),
            (dRow: -2, dColumn: 1),
            (dRow: -1, dColumn: -2),
            (dRow: -2, dColumn: -1)
        };

        Backtrack(r, c, 0);
        return ans;

        bool Backtrack(int row, int column, int step)
        {
            if (ans[row][column] != unset)
            {
                return false;
            }

            ans[row][column] = step;

            if (step == m * n - 1)
            {
                return true;
            }

            foreach (var (dRow, dColumn) in directions)
            {
                var nextRow = row + dRow;
                var nextColumn = column + dColumn;
                if (nextRow < 0 || nextRow >= m || nextColumn < 0 || nextColumn >= n)
                {
                    continue;
                }

                if (Backtrack(nextRow, nextColumn, step + 1))
                {
                    return true;
                }
            }

            ans[row][column] = unset;
            return false;
        }
    }
}
