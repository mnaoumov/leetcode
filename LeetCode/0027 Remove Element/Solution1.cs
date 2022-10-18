using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0027_Remove_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/811934718/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int RemoveElement(int[] nums, int val)
    {
        var index = 0;

        foreach (var num in nums)
        {
            if (num != val)
            {
                nums[index] = num;
                index++;
            }
        }

        return index;
    }
}