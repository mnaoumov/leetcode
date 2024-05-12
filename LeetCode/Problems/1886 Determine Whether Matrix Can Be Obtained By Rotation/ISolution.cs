using JetBrains.Annotations;

namespace LeetCode.Problems._1886_Determine_Whether_Matrix_Can_Be_Obtained_By_Rotation;

[PublicAPI]
public interface ISolution
{
    public bool FindRotation(int[][] mat, int[][] target);
}
