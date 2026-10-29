namespace LeetCode.Problems._2765_Longest_Alternating_Subarray;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-108/submissions/detail/989385713/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int AlternatingSubarray(int[] nums)
    {
        var ans = 0;

        const int initialPlusLength = 0;
        const int initialMinusLength = 1;

        var plusLength = initialPlusLength;
        var minusLength = initialMinusLength;

        for (var i = 1; i < nums.Length; i++)
        {
            switch (nums[i] - nums[i - 1])
            {
                case -1:
                    minusLength = plusLength + 1;
                    plusLength = initialPlusLength;
                    ans = Math.Max(ans, minusLength);
                    break;
                case 1:
                    plusLength = minusLength + 1;
                    minusLength = initialMinusLength;
                    ans = Math.Max(ans, plusLength);
                    break;
                default:
                    plusLength = initialPlusLength;
                    minusLength = initialMinusLength;
                    break;
            }
        }

        return ans < 2 ? -1 : ans;
    }
}
