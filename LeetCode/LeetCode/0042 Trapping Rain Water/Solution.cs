namespace LeetCode._0042_Trapping_Rain_Water;

public class Solution : ISolution
{
    public int Trap(int[] height)
    {
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