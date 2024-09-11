using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._2505_Bitwise_OR_of_All_Subsequence_Sums;

/// <summary>
/// https://leetcode.com/submissions/detail/869950796/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public long SubsequenceSumOr(int[] nums)
    {
        var result = 0;
        var sum = 0;
        foreach (var num in nums)
        {
            result |= num;
            sum += num;
            result |= sum;
        }

        return result;
    }
}
