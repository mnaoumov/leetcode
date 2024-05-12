using JetBrains.Annotations;

namespace LeetCode._0287_Find_the_Duplicate_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/933121615/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int FindDuplicate(int[] nums)
    {
        var slow = nums[0];
        var fast = nums[0];

        do
        {
            slow = nums[slow];
            fast = nums[nums[fast]];
        } while (slow != fast);

        var num1 = nums[0];
        var num2 = slow;

        while (num1 != num2)
        {
            num1 = nums[num1];
            num2 = nums[num2];
        }

        return num1;
    }
}
