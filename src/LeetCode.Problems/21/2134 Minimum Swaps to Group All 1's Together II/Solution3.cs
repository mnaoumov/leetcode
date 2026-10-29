namespace LeetCode.Problems._2134_Minimum_Swaps_to_Group_All_1_s_Together_II;

/// <summary>
/// https://leetcode.com/submissions/detail/1341314864/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int MinSwaps(int[] nums)
    {
        var total = nums.Count(num => num == 1);

        if (total == 0)
        {
            return 0;
        }

        var zerosCount = 0;

        for (var i = 0; i < total; i++)
        {
            if (nums[i] == 0)
            {
                zerosCount++;
            }
        }

        var ans = zerosCount;

        var n = nums.Length;

        for (var start = 1; start < n; start++)
        {
            var end = (start + total - 1) % n;

            zerosCount += nums[end] == 0 ? 1 : 0;
            zerosCount -= nums[start - 1] == 0 ? 1 : 0;
            ans = Math.Min(ans, zerosCount);
        }

        return ans;
    }
}
