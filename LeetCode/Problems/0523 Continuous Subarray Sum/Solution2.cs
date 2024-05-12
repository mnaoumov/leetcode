using JetBrains.Annotations;
// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0523_Continuous_Subarray_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/830306234/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var mods = new HashSet<int>();
        var lastMod = 0;

        foreach (var num in nums)
        {
            lastMod = (lastMod + num) % k;

            if (!mods.Add(lastMod) || (lastMod == 0 && mods.Count > 1))
            {
                return true;
            }
        }

        return false;
    }
}
