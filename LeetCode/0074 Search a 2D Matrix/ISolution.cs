using JetBrains.Annotations;

namespace LeetCode._0074_Search_a_2D_Matrix;

[PublicAPI]
public interface ISolution
{
    public bool SearchMatrix(int[][] matrix, int target);
}