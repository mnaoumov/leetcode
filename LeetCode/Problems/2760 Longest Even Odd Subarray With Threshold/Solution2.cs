namespace LeetCode.Problems._2760_Longest_Even_Odd_Subarray_With_Threshold;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-352/submissions/detail/984141964/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestAlternatingSubarray(int[] nums, int threshold)
    {
        var ans = 0;

        var nextRemainder = 0;
        var subarrayLength = 0;

        foreach (var num in nums)
        {
            var remainder = num % 2;

            if (num > threshold || remainder == 1 && nextRemainder == 0)
            {
                nextRemainder = 0;
                subarrayLength = 0;
                continue;
            }

            if (remainder == nextRemainder)
            {
                subarrayLength++;
                nextRemainder ^= 1;
            }
            else
            {
                subarrayLength = 1;
                nextRemainder = 1;
            }

            ans = Math.Max(ans, subarrayLength);
        }

        return ans;
    }
}
