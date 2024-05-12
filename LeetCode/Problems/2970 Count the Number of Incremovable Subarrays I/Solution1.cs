using JetBrains.Annotations;

namespace LeetCode.Problems._2970_Count_the_Number_of_Incremovable_Subarrays_I;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-120/submissions/detail/1126659027/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int IncremovableSubarrayCount(int[] nums)
    {
        var n = nums.Length;
        var ans = 0;

        var maxSortedPrefixIndex = 0;

        for (var i = 1; i < n; i++)
        {
            if (nums[i] <= nums[i - 1])
            {
                break;
            }

            maxSortedPrefixIndex++;
        }

        var minSortedSuffixIndex = n - 1;

        for (var i = n - 2; i >= 0; i--)
        {
            if (nums[i] >= nums[i + 1])
            {
                break;
            }

            minSortedSuffixIndex--;
        }

        for (var i = 0; i < Math.Min(maxSortedPrefixIndex + 2, n); i++)
        {
            for (var j = Math.Max(i + 1, minSortedSuffixIndex); j <= n; j++)
            {
                if (i == 0 || j == n || nums[i - 1] < nums[j])
                {
                    ans++;
                }
            }
        }

        return ans;
    }
}
