namespace LeetCode.Problems._0724_Find_Pivot_Index;

/// <summary>
/// https://leetcode.com/submissions/detail/898923574/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int PivotIndex(int[] nums)
    {
        var n = nums.Length;
        var sums = new int[n + 1];

        for (var i = 0; i < n; i++)
        {
            sums[i + 1] = sums[i] + nums[i];
        }

        for (var i = 0; i < n; i++)
        {
            var sumLeft = sums[i];
            var sumRight = sums[^1] - sums[i + 1];

            if (sumLeft == sumRight)
            {
                return i;
            }
        }

        return -1;
    }
}
