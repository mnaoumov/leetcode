using JetBrains.Annotations;

namespace LeetCode.Problems._2250_Count_Number_of_Rectangles_Containing_Each_Point;

/// <summary>
/// https://leetcode.com/submissions/detail/915179892/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.TimeLimitExceeded)]
public class Solution2 : ISolution
{
    public int[] CountRectangles(int[][] rectangles, int[][] points)
    {
        var sortedRectangles = rectangles.Select(r => (length: r[0], height: r[1])).OrderBy(r => r.length).ToArray();
        var lengths = sortedRectangles.Select(r => r.length).ToArray();

        var result = new int[points.Length];

        for (var i = 0; i < result.Length; i++)
        {
            var point = points[i];
            var lengthIndex = BinarySearch(lengths, point[0]);

            var heights = sortedRectangles.Skip(lengthIndex).Select(r => r.height).OrderBy(x => x).ToArray();

            var heightIndex = BinarySearch(heights, point[1]);
            result[i] = heights.Length - heightIndex;
        }

        return result;
    }

    private static int BinarySearch<T>(IReadOnlyList<T> arr, T value) where T : IComparable<T>
    {
        var low = 0;
        var high = arr.Count - 1;

        while (low <= high)
        {
            var mid = low + (high - low >> 1);

            if (value.CompareTo(arr[mid]) <= 0)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }
}
