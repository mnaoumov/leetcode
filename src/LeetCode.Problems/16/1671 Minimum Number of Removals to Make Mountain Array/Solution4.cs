namespace LeetCode.Problems._1671_Minimum_Number_of_Removals_to_Make_Mountain_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1438337862/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public int MinimumMountainRemovals(int[] nums)
    {
        var n = nums.Length;

        var longestIncreasingLengths = Enumerable.Repeat(1, n).ToArray();

        for (var i = 0; i < n; i++)
        {
            for (var j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    longestIncreasingLengths[i] = Math.Max(longestIncreasingLengths[i], longestIncreasingLengths[j] + 1);
                }
            }
        }

        var longestDecreasingLengths = Enumerable.Repeat(1, n).ToArray();

        for (var i = n - 1; i >= 0; i--)
        {
            for (var j = n - 1; j > i; j--)
            {
                if (nums[i] > nums[j])
                {
                    longestDecreasingLengths[i] = Math.Max(longestDecreasingLengths[i], longestDecreasingLengths[j] + 1);
                }
            }
        }

        var ans = int.MaxValue;

        for (var i = 0; i < n; i++)
        {
            if (longestIncreasingLengths[i] > 1 && longestDecreasingLengths[i] > 1)
            {
                ans = Math.Min(ans, n - longestIncreasingLengths[i] - longestDecreasingLengths[i] + 1);
            }
        }

        return ans;
    }
}