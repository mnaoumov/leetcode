using JetBrains.Annotations;

namespace LeetCode._0035_Search_Insert_Position;

/// <summary>
/// https://leetcode.com/submissions/detail/813032548/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int SearchInsert(int[] nums, int target)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] >= target)
            {
                return i;
            }
        }

        return nums.Length;
    }
}
