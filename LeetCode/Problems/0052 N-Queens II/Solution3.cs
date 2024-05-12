using JetBrains.Annotations;

namespace LeetCode._0052_N_Queens_II;

/// <summary>
/// https://leetcode.com/submissions/detail/918847769/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int TotalNQueens(int n)
    {
        var result = 0;
        var columnsTaken = new HashSet<int>();
        var diagonalsTaken = new HashSet<int>();
        var antiDiagonalsTaken = new HashSet<int>();
        Backtrack(0);
        return result;

        void Backtrack(int row)
        {
            if (row == n)
            {
                result++;
                return;
            }

            for (var column = 0; column < n; column++)
            {
                var diagonalIndex = row - column;
                var antiDiagonalIndex = row + column;

                if (columnsTaken.Contains(column)
                    || diagonalsTaken.Contains(diagonalIndex)
                    || antiDiagonalsTaken.Contains(antiDiagonalIndex))
                {
                    continue;
                }

                columnsTaken.Add(column);
                diagonalsTaken.Add(diagonalIndex);
                antiDiagonalsTaken.Add(antiDiagonalIndex);
                Backtrack(row + 1);
                columnsTaken.Remove(column);
                diagonalsTaken.Remove(diagonalIndex);
                antiDiagonalsTaken.Remove(antiDiagonalIndex);
            }
        }
    }
}
