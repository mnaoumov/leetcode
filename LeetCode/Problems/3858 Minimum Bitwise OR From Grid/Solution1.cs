namespace LeetCode.Problems._3858_Minimum_Bitwise_OR_From_Grid;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-491/problems/minimum-bitwise-or-from-grid/submissions/1934255487/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinimumOR(int[][] grid)
    {
        var m = grid.Length;

        const int maxBit = 16; // 100_000 < 2^17

        var ans = 0;

        for (var bit = maxBit; bit >= 0; bit--)
        {
            var bitValue = 1 << bit;

            var filteredGrid = new int[m][];

            for (var i = 0; i < m; i++)
            {
                var row = grid[i];
                var filteredRow = row.Where(num => (num & bitValue) == 0).ToArray();

                if (filteredRow.Length != 0)
                {
                    filteredGrid[i] = filteredRow;
                    continue;
                }

                ans ^= bitValue;
                filteredGrid = grid;
                break;
            }

            grid = filteredGrid;
        }

        return ans;
    }
}
