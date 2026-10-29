namespace LeetCode.Problems._3350_Adjacent_Increasing_Subarrays_Detection_II;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-423/submissions/detail/1448211281/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxIncreasingSubarrays(IList<int> nums)
    {
        var n = nums.Count;

        var lengths = new List<int> { 1 };

        for (var i = 1; i < n; i++)
        {
            if (nums[i] > nums[i - 1])
            {
                lengths[^1]++;
            }
            else
            {
                lengths.Add(1);
            }
        }

        var ans = lengths[0] / 2;

        var m = lengths.Count;

        for (var i = 1; i < m; i++)
        {
            ans = Math.Max(ans, lengths[i] / 2);
            ans = Math.Max(ans, Math.Min(lengths[i], lengths[i - 1]));
        }

        return ans;
    }
}
