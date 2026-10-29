namespace LeetCode.Problems._0209_Minimum_Size_Subarray_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/898898647/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinSubArrayLen(int target, int[] nums)
    {
        var i = 0;
        var j = 0;
        var sum = 0;
        var result = int.MaxValue;

        var n = nums.Length;

        while (i < n)
        {
            while (j < n && sum < target)
            {
                sum += nums[j];
                j++;
            }

            if (sum >= target)
            {
                result = Math.Min(result, j - i);
            }

            sum -= nums[i];
            i++;
        }

        return result == int.MaxValue ? 0 : result;
    }
}
