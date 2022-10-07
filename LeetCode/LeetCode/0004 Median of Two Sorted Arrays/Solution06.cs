namespace LeetCode._0004_Median_of_Two_Sorted_Arrays;

/// <summary>
/// https://leetcode.com/submissions/detail/200389192/
/// </summary>
public class Solution06 : ISolution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var n1 = nums1.Length;
        var n2 = nums2.Length;
        var medianItemIndex1 = (n1 + n2 - 1) / 2;
        var medianItemIndex2 = medianItemIndex1 + (n1 + n2 - 1) % 2;
        int medianValue1 = 0;
        int medianValue2 = 0;

        var index1 = 0;
        var index2 = 0;

        var mergeIndex = 0;
        while (mergeIndex <= medianItemIndex2)
        {
            int value;

            if (index1 < n1 && (index2 >= n2 || nums1[index1] <= nums2[index2]))
            {
                value = nums1[index1];
                index1++;
            }
            else
            {
                value = nums2[index2];
                index2++;
            }

            if (mergeIndex == medianItemIndex1)
            {
                medianValue1 = value;
            }

            if (mergeIndex == medianItemIndex2)
            {
                medianValue2 = value;
            }

            mergeIndex++;
        }

        return (medianValue1 + medianValue2) / 2.0;
    }
}