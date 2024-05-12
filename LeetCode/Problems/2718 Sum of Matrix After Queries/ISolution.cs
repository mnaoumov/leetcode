using JetBrains.Annotations;

namespace LeetCode.Problems._2718_Sum_of_Matrix_After_Queries;

[PublicAPI]
public interface ISolution
{
    public long MatrixSumQueries(int n, int[][] queries);
}
