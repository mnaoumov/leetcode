namespace LeetCode.Problems._3375_Minimum_Operations_to_Make_Array_Values_Equal_to_K;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-145/submissions/detail/1472659480/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MinOperations(int[] nums, int k)
    {
        var min = nums.Min();

        if (min < k)
        {
            return -1;
        }

        var distinctCount = nums.Distinct().Count();
        return min == k ? distinctCount - 1 : distinctCount;
    }
}
