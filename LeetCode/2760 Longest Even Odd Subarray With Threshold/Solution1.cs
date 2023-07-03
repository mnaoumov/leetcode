using JetBrains.Annotations;

namespace LeetCode._2760_Longest_Even_Odd_Subarray_With_Threshold;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984134490/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int LongestAlternatingSubarray(int[] nums, int threshold)
    {
        var ans = 0;

        var nextRemainder = 0;
        var subarrayLength = 0;

        foreach (var num in nums)
        {
            if (num > threshold)
            {
                nextRemainder = 0;
                subarrayLength = 0;
                continue;
            }

            var remainder = num % 2;

            if (remainder == nextRemainder)
            {
                subarrayLength++;
                nextRemainder ^= 1;
            }
            else if (remainder == 0)
            {
                subarrayLength = 1;
                nextRemainder = 1;
            }

            ans = Math.Max(ans, subarrayLength);
        }

        return ans;
    }
}
