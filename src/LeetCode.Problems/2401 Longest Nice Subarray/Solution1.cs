namespace LeetCode.Problems._2401_Longest_Nice_Subarray;

/// <summary>
/// https://leetcode.com/problems/longest-nice-subarray/submissions/1577349103/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestNiceSubarray(int[] nums)
    {
        var ans = 1;
        const int maxPossibleAns = 30;

        var length = 0;
        var xor = 0;

        foreach (var num in nums)
        {
            if ((num & xor) == 0)
            {
                length++;
                xor ^= num;
            }
            else
            {
                length = 1;
                xor = num;
            }

            ans = Math.Max(ans, length);

            if (ans == maxPossibleAns)
            {
                break;
            }
        }

        return ans;
    }
}
