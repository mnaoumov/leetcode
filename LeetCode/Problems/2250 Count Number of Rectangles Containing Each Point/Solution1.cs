using JetBrains.Annotations;

namespace LeetCode.Problems._2250_Count_Number_of_Rectangles_Containing_Each_Point;

/// <summary>
/// https://leetcode.com/submissions/detail/915172822/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int[] CountRectangles(int[][] rectangles, int[][] points)
    {
        var lengths = rectangles.Select(r => r[0]).OrderBy(x => x).ToArray();
        var heights = rectangles.Select(r => r[1]).OrderBy(x => x).ToArray();

        var result = new int[points.Length];

        for (var i = 0; i < result.Length; i++)
        {
            var point = points[i];
            var lengthIndex = BinarySearch(lengths, point[0]);
            var heightIndex = BinarySearch(heights, point[1]);
            result[i] = points.Length - Math.Max(lengthIndex, heightIndex);
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

        return low - 1;
    }
}
