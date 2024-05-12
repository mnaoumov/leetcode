using JetBrains.Annotations;

namespace LeetCode.Problems._1074_Number_of_Submatrices_That_Sum_to_Target;

[PublicAPI]
public interface ISolution
{
    public int NumSubmatrixSumTarget(int[][] matrix, int target);
}
