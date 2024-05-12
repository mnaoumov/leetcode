using JetBrains.Annotations;

namespace LeetCode.Problems._0084_Largest_Rectangle_in_Histogram;

/// <summary>
/// https://leetcode.com/submissions/detail/826966236/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int LargestRectangleArea(int[] heights)
    {
        var n = heights.Length;
        var result = 0;

        var nextPairs = new List<(int height, int width)>();

        for (var i = n - 1; i >= 0; i--)
        {
            var currentHeight = heights[i];
            var pairs = new List<(int height, int width)>();

            var lastWidthWithBiggerHeight = 0;

            foreach (var (height, width) in nextPairs)
            {
                if (height >= currentHeight)
                {
                    lastWidthWithBiggerHeight = width;
                }
                else
                {
                    pairs.Add((height, width + 1));
                    result = Math.Max(result, height * (width + 1));
                }
            }

            pairs.Insert(0, (currentHeight, lastWidthWithBiggerHeight + 1));
            result = Math.Max(result, currentHeight * (lastWidthWithBiggerHeight + 1));

            nextPairs = pairs;
        }

        return result;
    }
}
