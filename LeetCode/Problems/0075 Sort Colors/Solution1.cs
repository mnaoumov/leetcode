

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0075_Sort_Colors;

/// <summary>
/// https://leetcode.com/submissions/detail/196742471/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void SortColors(int[] nums)
    {
        var counts = new int[3];
        foreach (var num in nums)
        {
            counts[num]++;
        }

        var lastColor = 0;
        var lastColorIndexShift = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i >= counts[lastColor] + lastColorIndexShift)
            {
                lastColor++;
                lastColorIndexShift = i;
            }

            nums[i] = lastColor;
        }
    }
}
