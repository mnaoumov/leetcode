using JetBrains.Annotations;

namespace LeetCode.Problems._0350_Intersection_of_Two_Arrays_II;

/// <summary>
/// https://leetcode.com/submissions/detail/922822201/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int[] Intersect(int[] nums1, int[] nums2)
    {
        Array.Sort(nums1);
        Array.Sort(nums2);

        var index1 = 0;
        var index2 = 0;

        var list = new List<int>();

        while (index1 < nums1.Length && index2 < nums2.Length)
        {
            var num1 = nums1[index1];
            var num2 = nums2[index2];

            if (num1 == num2)
            {
                list.Add(num1);
                index1++;
                index2++;
            }
            else if (num1 < num2)
            {
                index1++;
            }
            else
            {
                index2++;
            }
        }

        return list.ToArray();
    }
}
