namespace LeetCode.Problems._0084_Largest_Rectangle_in_Histogram;

/// <summary>
/// https://leetcode.com/submissions/detail/826838110/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int LargestRectangleArea(int[] heights)
    {
        var n = heights.Length;
        var result = 0;

        var previousMinHeights = new List<int>();

        for (var i = n - 1; i >= 0; i--)
        {
            var height = heights[i];
            var minHeights = new List<int> { height };
            result = Math.Max(result, height);

            var width = 1;
            foreach (var previousMinHeight in previousMinHeights)
            {
                width++;
                var minHeight = Math.Min(height, previousMinHeight);
                minHeights.Add(minHeight);
                result = Math.Max(result, minHeight * width);
            }

            previousMinHeights = minHeights;
        }

        return result;
    }
}
