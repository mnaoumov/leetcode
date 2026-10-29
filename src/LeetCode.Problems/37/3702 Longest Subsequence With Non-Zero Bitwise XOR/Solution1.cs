namespace LeetCode.Problems._3702_Longest_Subsequence_With_Non_Zero_Bitwise_XOR;

/// <summary>
/// https://leetcode.com/problems/longest-subsequence-with-non-zero-bitwise-xor/submissions/2107210029/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestSubsequence(int[] nums)
    {
        var xor = nums.Aggregate((a, b) => a ^ b);

        if (xor != 0)
        {
            return nums.Length;
        }

        for (var i = 0; i < nums.Length / 2; i++)
        {
            if (nums[i] != 0 || nums[^(i + 1)] != 0)
            {
                return nums.Length - 1 - i;
            }
        }

        return 0;
    }
}
