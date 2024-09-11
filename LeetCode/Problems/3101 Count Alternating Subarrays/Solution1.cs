namespace LeetCode.Problems._3101_Count_Alternating_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-391/submissions/detail/1218762852/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public long CountAlternatingSubarrays(int[] nums)
    {
        var n = nums.Length;
        var counts = new long[n];
        var ans = 1L;

        counts[n - 1] = 1;

        for (var i = n - 2; i >= 0; i--)
        {
            counts[i] = 1 + (nums[i] == nums[i + 1] ? 0 : counts[i + 1]);
            ans += counts[i];
        }

        return ans;
    }
}
