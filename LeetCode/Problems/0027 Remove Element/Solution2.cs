using JetBrains.Annotations;

namespace LeetCode.Problems._0027_Remove_Element;

/// <summary>
/// https://leetcode.com/submissions/detail/829013909/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int RemoveElement(int[] nums, int val)
    {
        var index = 0;

        foreach (var num in nums)
        {
            if (num == val)
            {
                continue;
            }

            nums[index] = num;
            index++;
        }

        return index;
    }
}
