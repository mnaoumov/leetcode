namespace LeetCode.Problems._2302_Count_Subarrays_With_Score_Less_Than_K;

/// <summary>
/// https://leetcode.com/problems/count-subarrays-with-score-less-than-k/submissions/1619816185/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountSubarrays(int[] nums, long k)
    {
        var ans = 0L;
        var i = 0;
        var sum = 0L;

        for (var j = 0; j < nums.Length; j++)
        {
            var num = nums[j];
            sum += num;

            while (sum * (j - i + 1) >= k)
            {
                sum -= nums[i];
                i++;
            }

            ans += j - i + 1;
        }

        return ans;
    }
}
