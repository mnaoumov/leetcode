using JetBrains.Annotations;

namespace LeetCode.Problems._3086_Minimum_Moves_to_Pick_K_Ones;

[PublicAPI]
public interface ISolution
{
    public long MinimumMoves(int[] nums, int k, int maxChanges);
}
