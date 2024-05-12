using JetBrains.Annotations;

namespace LeetCode.Problems._0311_Sparse_Matrix_Multiplication;

/// <summary>
/// https://leetcode.com/submissions/detail/925596231/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[][] Multiply(int[][] mat1, int[][] mat2)
    {
        var m = mat1.Length;
        var k = mat1[0].Length;
        var n = mat2[0].Length;

        var nonEmptyRows1 = Enumerable.Range(0, m).Where(rowIndex1 => mat1[rowIndex1].Any(num => num != 0)).ToList();
        var nonEmptyColumns2 = Enumerable.Range(0, n).Where(columnIndex2 => mat2.Any(row2 => row2[columnIndex2] != 0)).ToList();

        var result = Enumerable.Range(0, m).Select(_ => new int[n]).ToArray();

        foreach (var rowIndex1 in nonEmptyRows1)
        {
            foreach (var columnIndex2 in nonEmptyColumns2)
            {
                result[rowIndex1][columnIndex2] = Enumerable.Range(0, k)
                    .Sum(index => mat1[rowIndex1][index] * mat2[index][columnIndex2]);
            }
        }

        return result;
    }
}
