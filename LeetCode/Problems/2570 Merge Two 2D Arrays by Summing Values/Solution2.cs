using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2570_Merge_Two_2D_Arrays_by_Summing_Values;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-333/submissions/detail/900681835/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution2 : ISolution
{
    public int[][] MergeArrays(int[][] nums1, int[][] nums2)
    {
        var ids = new HashSet<int>();

        foreach (var num in nums1)
        {
            ids.Add(num[0]);
        }

        foreach (var num in nums2)
        {
            ids.Add(num[0]);
        }

        var result = new int[ids.Count][];

        var index1 = 0;
        var index2 = 0;
        var resultIndex = 0;

        while (index1 < nums1.Length || index2 < nums2.Length)
        {
            var id1 = index1 < nums1.Length ? nums1[index1][0] : 0;
            var value1 = index1 < nums1.Length ? nums1[index1][1] : 0;
            var id2 = index2 < nums2.Length ? nums2[index2][0] : 0;
            var value2 = index2 < nums2.Length ? nums2[index2][1] : 0;

            if (id2 == 0 || id1 < id2)
            {
                result[resultIndex] = nums1[index1];
                index1++;
            }
            else if (id1 == 0 || id2 < id1)
            {
                result[resultIndex] = nums2[index2];
                index2++;
            }
            else if (id1 == id2)
            {
                result[resultIndex] = new[] { id1, value1 + value2 };
                index1++;
                index2++;
            }

            resultIndex++;
        }

        return result.ToArray();
    }
}
