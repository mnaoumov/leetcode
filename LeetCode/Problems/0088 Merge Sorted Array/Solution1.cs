namespace LeetCode.Problems._0088_Merge_Sorted_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/827634475/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        var result = new List<int> { Capacity = m + n };

        var i = 0;
        var j = 0;

        while (i < m || j < n)
        {
            int value;
            if (j >= n || i < m && nums1[i] < nums2[j])
            {
                value = nums1[i];
                i++;
            }
            else
            {
                value = nums2[j];
                j++;
            }

            result.Add(value);
        }

        for (i = 0; i < nums1.Length; i++)
        {
            nums1[i] = result[i];
        }
    }
}
