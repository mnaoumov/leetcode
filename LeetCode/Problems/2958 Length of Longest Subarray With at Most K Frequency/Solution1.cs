using JetBrains.Annotations;

namespace LeetCode.Problems._2958_Length_of_Longest_Subarray_With_at_Most_K_Frequency;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-119/submissions/detail/1115780218/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxSubarrayLength(int[] nums, int k)
    {
        var ans = 0;
        var counts = new Dictionary<int, int>();

        var j = 0;

        for (var i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            counts.TryAdd(num, 0);
            counts[num]++;

            while (counts[num] > k)
            {
                var previousNum = nums[j];
                counts[previousNum]--;
                j++;
            }

            ans = Math.Max(ans, i - j + 1);
        }

        return ans;
    }
}
