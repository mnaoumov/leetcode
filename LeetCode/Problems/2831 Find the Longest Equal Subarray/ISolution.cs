using JetBrains.Annotations;

namespace LeetCode.Problems._2831_Find_the_Longest_Equal_Subarray;

[PublicAPI]
public interface ISolution
{
    public int LongestEqualSubarray(IList<int> nums, int k);
}
