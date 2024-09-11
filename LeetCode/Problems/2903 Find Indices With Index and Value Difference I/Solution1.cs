namespace LeetCode.Problems._2903_Find_Indices_With_Index_and_Value_Difference_I;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-367/submissions/detail/1075429618/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] FindIndices(int[] nums, int indexDifference, int valueDifference)
    {
        var n = nums.Length;
        for (var i = 0; i < n; i++)
        {
            for (var j = i + indexDifference; j < n; j++)
            {
                if (Math.Abs(nums[i] - nums[j]) >= valueDifference)
                {
                    return new[] { i, j };
                }
            }
        }

        return new[] { -1, -1 };
    }
}
