using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._2326_Spiral_Matrix_IV;

[PublicAPI]
public interface ISolution
{
    public int[][] SpiralMatrix(int m, int n, ListNode head);
}
