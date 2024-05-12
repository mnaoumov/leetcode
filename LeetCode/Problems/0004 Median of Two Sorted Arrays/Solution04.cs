using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0004_Median_of_Two_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/147422858/
/// </summary>
[UsedImplicitly]
public class Solution04 : ISolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var a = nums1;
        var b = nums2;

        if (a.Length > b.Length)
        {
            var temp = a;
            a = b;
            b = temp;
        }

        // a - shorter array

        var m = a.Length;
        var n = b.Length;
        var middleLength = (m + n + 1) / 2;

        // A[i - 1] <= B[j]
        // B[j - 1] <= A[i]
        // i > 0 => j < n

        var iMin = 0;
        var iMax = m;

        while (iMin <= iMax)
        {
            var i = (iMin + iMax) / 2;
            var j = middleLength - i;

            if (i >= 0 && i < m && j >= 1 && b[j - 1] > a[i])
            {
                iMin = i + 1;
            }
            else if (i >= 1 && i < m && j >= 0 && j < n && a[i - 1] > b[j])
            {
                iMax = i - 1;
            }
            else
            {
                var maxLeft = int.MinValue;
                if (i > 0)
                    maxLeft = Math.Max(maxLeft, a[i - 1]);
                if (j > 0)
                    maxLeft = Math.Max(maxLeft, b[j - 1]);

                if ((m + n) % 2 == 1)
                    return maxLeft;

                var minRight = int.MaxValue;

                if (i < m)
                    minRight = Math.Min(minRight, a[i]);
                if (j < n)
                    minRight = Math.Min(minRight, b[j]);

                return ((double) maxLeft + minRight) / 2;
            }
        }

        throw new NotSupportedException();
    }
}
