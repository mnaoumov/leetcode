using JetBrains.Annotations;

namespace LeetCode.Problems._2570_Merge_Two_2D_Arrays_by_Summing_Values;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-333/submissions/detail/900675791/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        var result = new List<int[]>();

        var index1 = 0;
        var index2 = 0;

        while (index1 < nums1.Length || index2 < nums2.Length)
        {
            var key1 = index1 < nums1.Length ? nums1[index1][0] : 0;
            var value1 = index1 < nums1.Length ? nums1[index1][1] : 0;
            var key2 = index2 < nums2.Length ? nums2[index2][0] : 0;
            var value2 = index2 < nums2.Length ? nums2[index2][1] : 0;

            if (key2 == 0 || key1 < key2)
            {
                result.Add(new[] { key1, value1 });
                index1++;
            }
            else if (key1 == 0 || key2 < key1)
            {
                result.Add(new[] { key2, value2 });
                index2++;
            }
            else if (key1 == key2)
            {
                result.Add(new[] { key1, value1 + value2 });
                index1++;
                index2++;
            }
        }

        return result.ToArray();
    }
}
