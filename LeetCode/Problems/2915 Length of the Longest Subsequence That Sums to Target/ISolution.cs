using JetBrains.Annotations;

namespace LeetCode._2915_Length_of_the_Longest_Subsequence_That_Sums_to_Target;

[PublicAPI]
public interface ISolution
{
    public int LengthOfLongestSubsequence(IList<int> nums, int target);
}
