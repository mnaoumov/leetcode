using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0330_Patching_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/1290611673/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public int MinPatches(int[] nums, int n)
    {
        var firstMissing = 1L;
        var ans = 0;
        foreach (var num in nums)
        {
            while (firstMissing < Math.Min(num, n - num))
            {
                ans++;
                firstMissing *= 2;
            }

            firstMissing += num;
            if (firstMissing > n) return ans;
        }

        return 0;
    }
}
