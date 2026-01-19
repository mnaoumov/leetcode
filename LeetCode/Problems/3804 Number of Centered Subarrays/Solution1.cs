namespace LeetCode.Problems._3804_Number_of_Centered_Subarrays;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-484/problems/number-of-centered-subarrays/submissions/1881256704/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int CenteredSubarrays(int[] nums)
    {
        var n = nums.Length;
        var ans = 0;
        for (var i = 0; i < n; i++)
        {
            var sum = 0;
            var set = new HashSet<int>();

            for (var j = i; j < n; j++)
            {
                set.Add(nums[j]);
                sum += nums[j];

                if (set.Contains(sum))
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
