using JetBrains.Annotations;

namespace LeetCode._0799_Champagne_Tower;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public double ChampagneTower(int poured, int query_row, int query_glass)
    {
        var nextRow = new double[] { poured };

        for (var rowIndex = 0; rowIndex <= query_row; rowIndex++)
        {
            var currentRow = nextRow;
            nextRow = new double[rowIndex + 2];
                
            for (var glassIndex = 0; glassIndex <= rowIndex ; glassIndex++)
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