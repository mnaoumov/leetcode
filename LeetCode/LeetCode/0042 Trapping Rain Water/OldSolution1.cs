namespace LeetCode._0042_Trapping_Rain_Water;

/// <summary>
/// https://leetcode.com/submissions/detail/199912503/
/// </summary>
public class OldSolution1 : ISolution
{
    public int Trap(int[] height)
    {
        var maxRightHeights = new int[height.Length];

        for (int i = maxRightHeights.Length - 2; i >= 0; i--)
        {
            maxRightHeights[i] = Math.Max(maxRightHeights[i + 1], height[i + 1]);
        }

        int result = 0;
        int maxLeft = 0;

        for (int i = 0; i < height.Length; i++)
        {
            maxLeft = Math.Min(maxLeft, maxRightHeights[i]);
            if (height[i] >= maxLeft)
            {
                maxLeft = height[i];
            }
            else
            {
                result += maxLeft - height[i];
            }
        }

        return result;
    }
}