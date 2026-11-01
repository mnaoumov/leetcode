namespace LeetCode.Problems._0080_Remove_Duplicates_from_Sorted_Array_II;

/// <seealso href="https://leetcode.com/submissions/detail/829059312/">Submission</seealso>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int RemoveDuplicates(int[] nums)
    {
        var insertPosition = 0;

        foreach (var num in nums)
        {
            if (insertPosition >= 2 && num == nums[insertPosition - 2])
            {
                continue;
            }

            nums[insertPosition] = num;
            insertPosition++;
        }

        return insertPosition;
    }
}
