using JetBrains.Annotations;

namespace LeetCode._2459_Sort_Array_by_Moving_Items_to_Empty_Space;

/// <summary>
/// 
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SortArray(int[] nums)
    {
        for (var i = 0; i < nums.Length; i++)
        {
            if (nums[i] == i)
            {
                continue;
            }
        }

        return 0;
    }
}
