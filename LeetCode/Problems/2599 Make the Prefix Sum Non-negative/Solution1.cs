using JetBrains.Annotations;

namespace LeetCode.Problems._2599_Make_the_Prefix_Sum_Non_negative;

/// <summary>
/// https://leetcode.com/submissions/detail/920495939/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MakePrefSumNonNegative(int[] nums)
    {
        var prefixSum = 0;
        var list = nums.ToList();
        var result = 0;

        for (var i = 0; i < list.Count; i++)
        {
            var num = list[i];
            prefixSum += num;

            if (prefixSum >= 0)
            {
                continue;
            }

            list.Add(num);
            result++;
            prefixSum -= num;
        }

        return result;
    }
}
