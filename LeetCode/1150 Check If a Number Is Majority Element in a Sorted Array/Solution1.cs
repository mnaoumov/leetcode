using JetBrains.Annotations;

namespace LeetCode._1150_Check_If_a_Number_Is_Majority_Element_in_a_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/967744439/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public bool IsMajorityElement(int[] nums, int target)
    {
        var othersCount = 0;
        var maxOthersCount = (nums.Length + 1) / 2;

        foreach (var num in nums)
        {
            if (num == target)
            {
                continue;
            }

            othersCount++;

            if (othersCount >= maxOthersCount)
            {
                return false;
            }
        }

        return true;
    }
}
