using JetBrains.Annotations;

namespace LeetCode.Problems._1337_The_K_Weakest_Rows_in_a_Matrix;

[PublicAPI]
public interface ISolution
{
    public int[] KWeakestRows(int[][] mat, int k);
}
