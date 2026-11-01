namespace LeetCode.Problems._3702_Longest_Subsequence_With_Non_Zero_Bitwise_XOR;

/// <seealso href="https://leetcode.com/problems/longest-subsequence-with-non-zero-bitwise-xor/submissions/2107213606/"/>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestSubsequence(int[] nums) =>
        nums.Aggregate((a, b) => a ^ b) != 0
            ? nums.Length
            : nums.All(num => num == 0)
                ? 0
                : nums.Length - 1;
}
