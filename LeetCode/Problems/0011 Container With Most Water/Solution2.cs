using JetBrains.Annotations;

namespace LeetCode._0011_Container_With_Most_Water;

/// <summary>
/// https://leetcode.com/submissions/detail/808435334/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public int MaxArea(int[] height)
    {
        var result = 0;

        var i = 0;
        var j = height.Length - 1;

        while (i < j)
        {
            var area = Math.Min(height[i], height[j]) * (j - i);

            if (area > result)
            {
                result = area;
            }

            if (height[i] <= height[j])
            {
                i++;
            }
            else
            {
                j--;
            }
        }

        return result;
    }
}
