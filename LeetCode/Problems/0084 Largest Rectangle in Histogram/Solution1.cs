using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode._0084_Largest_Rectangle_in_Histogram;

/// <summary>
/// https://leetcode.com/submissions/detail/200371378/
/// https://leetcode.com/submissions/detail/826838110/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution1 : ISolution
{
    public int LargestRectangleArea(int[] heights)
    {
        var result = 0;

        foreach (var height in heights)
        {
            var sequentialBarsNotBelowCurrent = 0;
            foreach (var height2 in heights)
            {
                if (height2 >= height)
                {
                    sequentialBarsNotBelowCurrent++;
                    result = Math.Max(result, sequentialBarsNotBelowCurrent * height);
                }
                else
                {
                    sequentialBarsNotBelowCurrent = 0;
                }
            }
        }

        return result;
    }
}
