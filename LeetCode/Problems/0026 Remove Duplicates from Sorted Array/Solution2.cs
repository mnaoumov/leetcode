namespace LeetCode.Problems._0026_Remove_Duplicates_from_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/829013575/
/// https://leetcode.com/problems/remove-duplicates-from-sorted-array/submissions/841077699/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int RemoveDuplicates(int[] nums)
    {
        var index = 0;
        var count = 0;
        int? lastValue = null;

        foreach (var num in nums)
        {
            if (num == lastValue)
            {
                continue;
            }

            nums[index] = num;
            lastValue = num;
            index++;
            count++;
        }

        return count;
    }
}
