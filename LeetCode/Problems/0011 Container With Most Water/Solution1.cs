using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0011_Container_With_Most_Water;

/// <summary>
/// https://leetcode.com/submissions/detail/196729552/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int MaxArea(int[] height)
    {
        int xLeft = 0;
        int xRight = height.Length - 1;
        int maxArea = 0;
        while (xLeft < xRight)
        {
            var yLeft = height[xLeft];
            var yRight = height[xRight];
            int area = Math.Min(yLeft, yRight) * (xRight - xLeft);
            maxArea = Math.Max(maxArea, area);
            if (yLeft < yRight)
            {
                xLeft++;
            }
            else
            {
                xRight--;
            }
        }

        return maxArea;
    }
}
