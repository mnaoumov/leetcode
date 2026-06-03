namespace LeetCode.Problems._1064_Fixed_Point;

/// <summary>
/// https://leetcode.com/problems/fixed-point/submissions/2010303167/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int FixedPoint(int[] arr)
    {
        var n = arr.Length;

        if (arr[0] > 0 || arr[^1] - (n - 1) < 0)
        {
            return -1;
        }

        var low = 0;
        var high = n - 1;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;

            if (arr[mid] >= mid)
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low < n && arr[low] == low ? low : -1;
    }
}
