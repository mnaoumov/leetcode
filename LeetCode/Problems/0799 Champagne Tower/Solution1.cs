namespace LeetCode.Problems._0799_Champagne_Tower;

/// <summary>
/// https://leetcode.com/submissions/detail/1058217597/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    // ReSharper disable InconsistentNaming
    public double ChampagneTower(int poured, int query_row, int query_glass)
    // ReSharper restore InconsistentNaming
    {
        var nextRow = new double[] { poured };

        for (var rowIndex = 0; rowIndex <= query_row; rowIndex++)
        {
            var currentRow = nextRow;
            nextRow = new double[rowIndex + 2];

            for (var glassIndex = 0; glassIndex <= rowIndex; glassIndex++)
            {
                if (currentRow[glassIndex] <= 1)
                {
                    continue;
                }

                var extra = currentRow[glassIndex] - 1;
                currentRow[glassIndex] = 1;
                nextRow[glassIndex] += extra / 2;
                nextRow[glassIndex + 1] += extra / 2;
            }

            if (rowIndex == query_row)
            {
                return currentRow[query_glass];
            }
        }

        throw new InvalidOperationException();
    }
}
