using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0042_Trapping_Rain_Water;

/// <summary>
/// https://leetcode.com/submissions/detail/814596468/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int Trap(int[] height)
    {
        if (height[0] > height[^1])
        {
            Array.Reverse(height);
        }

        var result = 0;

        var left = 0;

        while (left < height.Length)
        {
            var right = left + 1;

            var waterFromTheLeft = 0;

            while (right < height.Length && height[left] > height[right])
            {
                waterFromTheLeft += height[left] - height[right];
                right++;
            }

            if (right < height.Length)
            {
                result += waterFromTheLeft;
                left = right;
            }
            else
            {
                left++;
            }
        }

        return result;
    }
}