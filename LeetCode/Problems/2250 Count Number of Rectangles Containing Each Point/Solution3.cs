using JetBrains.Annotations;

namespace LeetCode.Problems._2250_Count_Number_of_Rectangles_Containing_Each_Point;

/// <summary>
/// https://leetcode.com/submissions/detail/915309888/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public int[] CountRectangles(int[][] rectangles, int[][] points)
    {
        var dict = rectangles.Select(r => (length: r[0], height: r[1]))
            .GroupBy(r => r.height, r => r.length).ToDictionary(g => g.Key, g => g.OrderBy(length => length).ToArray());

        const int maxHeight = 100;

        var result = new int[points.Length];

        for (var i = 0; i < result.Length; i++)
        {
            var point = points[i];

            for (var height = point[1]; height <= maxHeight; height++)
            {
                var lengths = dict.GetValueOrDefault(height, Array.Empty<int>());
                var lengthIndex = Array.BinarySearch(lengths, point[0]);

                if (lengthIndex < 0)
                {
                    lengthIndex = ~lengthIndex;
                }

                result[i] += lengths.Length - lengthIndex;
            }
        }

        return result;
    }
}
