using JetBrains.Annotations;

namespace LeetCode._3012_Minimize_Length_of_Array_Using_Operations;

/// <summary>
/// https://leetcode.com/submissions/detail/1151667574/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MinimumArrayLength(int[] nums)
    {
        Array.Sort(nums);

        if (nums.Any(num => num % nums[0] != 0))
        {
            return 1;
        }

        var minCount = nums.TakeWhile(num => num == nums[0]).Count();
        return (minCount + 1) / 2;
    }
}
