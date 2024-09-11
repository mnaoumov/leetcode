using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2499_Minimum_Total_Cost_to_Make_Arrays_Unequal;

/// <summary>
/// https://leetcode.com/submissions/detail/858980314/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public long MinimumTotalCost(int[] nums1, int[] nums2)
    {
        var n = nums1.Length;

        var indicesToSwap = new HashSet<int>();
        var numCounts = new Dictionary<int, int>();
        var indicesToSwapSum = 0L;

        var maxCount = 0;
        var numToSwapCount = 0;
        var numWithMaxCount = 0;

        int i;

        for (i = 0; i < n; i++)
        {
            var num = nums1[i];

            if (num != nums2[i])
            {
                continue;
            }

            indicesToSwap.Add(i);
            indicesToSwapSum += i;
            numToSwapCount++;
            numCounts[num] = numCounts.GetValueOrDefault(num) + 1;

            if (numCounts[num] <= maxCount)
            {
                continue;
            }

            maxCount = numCounts[num];
            numWithMaxCount = num;
        }

        i = 0;

        while ((maxCount > numToSwapCount / 2 || numToSwapCount % 2 == 1 && !indicesToSwap.Contains(0)) && i < n)
        {
            if (!indicesToSwap.Contains(i) && nums1[i] != numWithMaxCount)
            {
                numToSwapCount++;
                indicesToSwapSum += i;
                indicesToSwap.Add(i);
            }

            i++;
        }

        if (maxCount > numToSwapCount / 2)
        {
            return -1;
        }

        return indicesToSwapSum;
    }
}
