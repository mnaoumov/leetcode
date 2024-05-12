using JetBrains.Annotations;

namespace LeetCode._3107_Minimum_Operations_to_Make_Median_of_Array_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-392/submissions/detail/1225360032/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long MinOperationsToMakeMedianK(int[] nums, int k)
    {
        Array.Sort(nums);

        var mid = nums.Length / 2;

        var ans = 0L;

        var i = mid;

        while (i >= 0 && nums[i] > k)
        {
            ans += nums[i] - k;
            nums[i] = k;
            i--;
        }

        i = mid;

        while (i < nums.Length && nums[i] < k)
        {
            ans += k - nums[i];
            nums[i] = k;
            i++;
        }

        return ans;
    }
}
