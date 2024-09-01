using JetBrains.Annotations;

namespace LeetCode.Problems._2022_Convert_1D_Array_Into_2D_Array;

[PublicAPI]
public interface ISolution
{
    public int[][] Construct2DArray(int[] original, int m, int n);
}
