using JetBrains.Annotations;

namespace LeetCode.Problems._1605_Find_Valid_Matrix_Given_Row_and_Column_Sums;

[PublicAPI]
public interface ISolution
{
    public int[][] RestoreMatrix(int[] rowSum, int[] colSum);
}
