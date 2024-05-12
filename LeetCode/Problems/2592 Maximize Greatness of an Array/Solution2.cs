using JetBrains.Annotations;

namespace LeetCode._2592_Maximize_Greatness_of_an_Array;

/// <summary>
/// https://leetcode.com/contest/biweekly-contest-100/submissions/detail/917502603/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaximizeGreatness(int[] nums)
    {
        Array.Sort(nums);
        var j = 1;

        for (var i = 0; i < nums.Length; i++)
        {
            while (j < nums.Length && nums[i] == nums[j])
            {
                j++;
            }

            if (j == nums.Length)
            {
                return i;
            }

            j++;
        }

        return 0;
    }
}
