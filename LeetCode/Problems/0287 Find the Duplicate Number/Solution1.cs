using JetBrains.Annotations;

namespace LeetCode.Problems._0287_Find_the_Duplicate_Number;

/// <summary>
/// https://leetcode.com/submissions/detail/933096443/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int FindDuplicate(int[] nums)
    {
        var n = nums.Length - 1;
        var result = nums[0];

        for (var i = 1; i <= n; i++)
        {
            result ^= i ^ nums[i];
        }

        return result;
    }
}
