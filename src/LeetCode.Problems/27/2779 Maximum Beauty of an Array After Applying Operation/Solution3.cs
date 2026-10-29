namespace LeetCode.Problems._2779_Maximum_Beauty_of_an_Array_After_Applying_Operation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-354/submissions/detail/995505087/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MaximumBeauty(int[] nums, int k)
    {
        Array.Sort(nums);

        var ans = 1;
        var i = 0;
        var n = nums.Length;

        for (var j = 0; j < n; j++)
        {
            while (nums[j] - nums[i] > 2 * k)
            {
                i++;
            }

            ans = Math.Max(ans, j - i + 1);
        }

        return ans;
    }
}
