namespace LeetCode.Problems._2765_Longest_Alternating_Subarray;

/// <summary>
/// https://leetcode.com/submissions/detail/989375803/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int AlternatingSubarray(int[] nums)
    {
        var ans = 0;

        var plusLength = 0;
        var minusLength = 1;

        for (var i = 1; i < nums.Length; i++)
        {
            switch (nums[i] - nums[i - 1])
            {
                case -1:
                    minusLength = plusLength + 1;
                    plusLength = 0;
                    ans = Math.Max(ans, minusLength);
                    break;
                case 1:
                    plusLength = minusLength + 1;
                    minusLength = 1;
                    ans = Math.Max(ans, plusLength);
                    break;
            }
        }

        return ans;
    }
}
