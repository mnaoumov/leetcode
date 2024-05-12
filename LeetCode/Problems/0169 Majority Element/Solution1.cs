using JetBrains.Annotations;

namespace LeetCode._0169_Majority_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/881539689/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MajorityElement(int[] nums)
    {
        var candidate = nums[0];
        var count = 1;

        foreach (var num in nums.Skip(1))
        {
            if (num == candidate)
            {
                count++;
            }
            else
            {
                count--;

                if (count != 0)
                {
                    continue;
                }

                candidate = num;
                count = 1;
            }
        }

        return candidate;
    }
}
