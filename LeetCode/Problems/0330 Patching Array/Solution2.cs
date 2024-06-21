using JetBrains.Annotations;

namespace LeetCode.Problems._0330_Patching_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1290623240/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public int MinPatches(int[] nums, int n)
    {
        var firstMissing = 1L;
        var ans = 0;
        foreach (var num in nums.Append(int.MaxValue))
        {
            while (firstMissing < num)
            {
                ans++;
                firstMissing *= 2;
            }

            firstMissing += num;
            if (firstMissing > n)
            {
                return ans;
            }
        }

        throw new InvalidOperationException();
    }
}
