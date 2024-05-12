using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0075_Sort_Colors;

/// <summary>
/// https://leetcode.com/submissions/detail/196747536/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public void SortColors(int[] nums)
    {
        int starting1Index = nums.Length;
        int starting2Index = nums.Length;

        int i = 0;
        while (i < starting1Index)
        {
            var num = nums[i];
            if (num == 0)
            {
                i++;
            }
            else if (num == 1)
            {
                starting1Index--;
                var t = nums[starting1Index];
                nums[starting1Index] = 1;
                nums[i] = t;
            }
            else if (num == 2)
            {
                starting2Index--;
                var t = nums[starting2Index];
                nums[starting2Index] = 2;
                nums[i] = t;
                if (starting1Index > starting2Index)
                {
                    starting1Index = starting2Index;
                }
            }
        }
    }
}
