using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0048_Rotate_Image;

/// <summary>
/// https://leetcode.com/submissions/detail/193997169/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void Rotate(int[][] matrix)
    {
        var array2D = ArrayHelper.ArrayOfArraysTo2D(matrix);
        Rotate(array2D);
        ArrayHelper.Copy2DToArrayOfArrays(array2D, matrix);
    }

    /// <summary>
    /// Was different signature
    /// </summary>
    /// <param name="matrix"></param>
    public void Rotate(int[,] matrix)
    {
        int n = matrix.GetLength(0);

        // i,j -> n-1-j,i

        var middleRowInclusive = (n - 1) / 2;
        var middleRowExclusive = n / 2 - 1;
        for (int i = 0; i <= middleRowInclusive; i++)
        {
            for (int j = 0; j <= middleRowExclusive; j++)
            {
                const int cycleLength = 4;
                int[] cycleValues = new int[cycleLength];
                int iCycle = i;
                int jCycle = j;

                void UpdateCycleVariables()
                {
                    (iCycle, jCycle) = (n - 1 - jCycle, iCycle);
                }

                for (int k = 0; k < cycleLength; k++)
                {
                    cycleValues[k] = matrix[iCycle, jCycle];
                    UpdateCycleVariables();
                }

                for (int k = 0; k < cycleLength; k++)
                {
                    matrix[iCycle, jCycle] = cycleValues[(k + 1) % cycleLength];
                    UpdateCycleVariables();
                }
            }
        }
    }
}
