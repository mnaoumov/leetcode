using JetBrains.Annotations;

namespace LeetCode.Problems._3152_Special_Array_II;

[PublicAPI]
public interface ISolution
{
    public bool[] IsArraySpecial(int[] nums, int[][] queries);
}
