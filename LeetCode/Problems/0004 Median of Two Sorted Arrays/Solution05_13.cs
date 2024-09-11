// ReSharper disable All
#pragma warning disable
using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0004_Median_of_Two_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/147552265/
/// https://leetcode.com/submissions/detail/815927580/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution05_13 : ISolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1);

        var a = nums1;
        var b = nums2;
        var m = a.Length;
        var n = b.Length;

        // looking for i, j
        // a[i - 1] <= b[j]
        // b[j - 1] <= a[i]

        var iMin = 0;
        var iMax = m;

        while (iMin <= iMax)
        {
            var i = (iMin + iMax) / 2;
            var j = (n + m + 1) / 2 - i;
            if (CheckIndices(i - 1, j, m, n) && a[i - 1] > b[j])
                iMax = i - 1;
            else if (CheckIndices(i, j - 1, m, n) && b[j - 1] > a[i])
                iMin = i + 1;
            else
            {
                var maxLeft = Math.Max(
                    i - 1 < 0 ? double.NegativeInfinity : a[i - 1],
                    j - 1 < 0 ? double.NegativeInfinity : b[j - 1]);

                if (m + n % 2 == 1)
                    return maxLeft;

                var minRight = Math.Min(
                    i >= m ? double.PositiveInfinity : a[i],
                    j >= n ? double.PositiveInfinity : b[j]);

                return (maxLeft + minRight) / 2.0;
            }
        }

        throw new ArgumentException();
    }

    static bool CheckIndices(int i, int j, int m, int n)
    {
        return i >= 0 && i < m && j >= 0 && j < n;
    }
}
