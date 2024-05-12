using JetBrains.Annotations;

namespace LeetCode.Problems._1199_Minimum_Time_to_Build_Blocks;

[PublicAPI]
public interface ISolution
{
    public int MinBuildTime(int[] blocks, int split);
}
