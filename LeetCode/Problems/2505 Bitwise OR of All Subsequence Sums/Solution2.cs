using JetBrains.Annotations;

namespace LeetCode.Problems._2505_Bitwise_OR_of_All_Subsequence_Sums;

/// <summary>
/// https://leetcode.com/submissions/detail/869952226/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public long SubsequenceSumOr(int[] nums)
    {
        long result = 0;
        long sum = 0;
        foreach (var num in nums)
        {
            result |= (uint) num;
            sum += num;
            result |= sum;
        }

        return result;
    }
}
