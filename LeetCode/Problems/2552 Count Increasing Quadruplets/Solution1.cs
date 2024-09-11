using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2552_Count_Increasing_Quadruplets;

/// <summary>
/// https://leetcode.com/submissions/detail/887540666/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public long CountQuadruplets(int[] nums)
    {
        var n = nums.Length;
        var iCounts = new Dictionary<(int j, int k), int>();
        var lCounts = new Dictionary<(int j, int k), int>();

        var result = 0L;

        for (var k = n - 2; k >= 0; k--)
        {
            for (var j = 0; j < k; j++)
            {
                lCounts[(j, k)] = lCounts.GetValueOrDefault((j, k + 1)) + (nums[k + 1] > nums[j] ? 1 : 0);
            }
        }

        for (var j = 1; j < n - 1; j++)
        {
            for (var k = j + 1; k < n - 1; k++)
            {
                iCounts[(j, k)] = iCounts.GetValueOrDefault((j - 1, k)) + (nums[k] > nums[j - 1] ? 1 : 0);

                if (nums[k] < nums[j])
                {
                    result += iCounts.GetValueOrDefault((j, k)) * lCounts.GetValueOrDefault((j, k));
                }
            }
        }

        return result;
    }
}
