namespace LeetCode.Problems._3392_Count_Subarrays_of_Length_Three_With_a_Condition;

/// <summary>
/// https://leetcode.com/problems/count-subarrays-of-length-three-with-a-condition/submissions/1619812901/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CountSubarrays(int[] nums)
    {
        var n = nums.Length;
        var ans = 0;
        for (var i = 0; i <= n - 3; i++)
        {
            if (2 * (nums[i] + nums[i + 2]) == nums[i + 1])
            {
                ans++;
            }
        }

        return ans;
    }
}
