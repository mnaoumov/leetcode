using JetBrains.Annotations;

namespace LeetCode._3107_Minimum_Operations_to_Make_Median_of_Array_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-392/submissions/detail/1225353815/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long MinOperationsToMakeMedianK(int[] nums, int k)
    {
        Array.Sort(nums);

        var mid = nums.Length / 2;

        var ans = 0L;

        var i = mid;

        while (nums[i] > k && i >= 0)
        {
            ans += nums[i] - k;
            nums[i] = k;
            i--;
        }

        i = mid;

        while (nums[i] < k && i < nums.Length)
        {
            ans += k - nums[i];
            nums[i] = k;
            i++;
        }

        return ans;
    }
}
