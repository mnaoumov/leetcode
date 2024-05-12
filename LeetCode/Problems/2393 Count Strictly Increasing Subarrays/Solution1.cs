using JetBrains.Annotations;

namespace LeetCode._2393_Count_Strictly_Increasing_Subarrays;

/// <summary>
/// https://leetcode.com/submissions/detail/1063082814/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountSubarrays(int[] nums)
    {
        var ans = 0L;

        var lastLength = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            if (i == 0 || nums[i] <= nums[i - 1])
            {
                lastLength = 1;
            }
            else
            {
                lastLength++;
            }

            ans += lastLength;
        }

        return ans;
    }
}
