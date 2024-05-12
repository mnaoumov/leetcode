using JetBrains.Annotations;

namespace LeetCode._1004_Max_Consecutive_Ones_III;

/// <summary>
/// https://leetcode.com/submissions/detail/855295402/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int LongestOnes(int[] nums, int k)
    {
        var result = 0;
        var zeroCount = 0;
        var left = 0;

        for (var right = 0; right < nums.Length; right++)
        {
            if (nums[right] == 0)
            {
                zeroCount++;
            }

            while (zeroCount > k && left < nums.Length)
            {
                if (nums[left] == 0)
                {
                    zeroCount--;
                }

                left++;
            }

            result = Math.Max(result, right - left + 1);
        }

        return result;
    }
}
