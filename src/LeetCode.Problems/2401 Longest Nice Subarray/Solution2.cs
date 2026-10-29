namespace LeetCode.Problems._2401_Longest_Nice_Subarray;

/// <summary>
/// https://leetcode.com/problems/longest-nice-subarray/submissions/1577353792/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int LongestNiceSubarray(int[] nums)
    {
        var ans = 1;
        const int maxPossibleAns = 30;

        var length = 0;
        var xor = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];

            while (length > 0 && (num & xor) != 0)
            {
                length--;
                xor ^= nums[i - 1 - length];
            }

            length++;
            xor ^= num;

            ans = Math.Max(ans, length);

            if (ans == maxPossibleAns)
            {
                break;
            }
        }

        return ans;
    }
}
