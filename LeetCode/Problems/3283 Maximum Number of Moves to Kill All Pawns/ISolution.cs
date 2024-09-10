using JetBrains.Annotations;

namespace LeetCode.Problems._3283_Maximum_Number_of_Moves_to_Kill_All_Pawns;

[PublicAPI]
public interface ISolution
{
    public int MaxMoves(int kx, int ky, int[][] positions);
}
