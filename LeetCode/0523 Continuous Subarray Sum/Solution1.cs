using JetBrains.Annotations;

namespace LeetCode._0523_Continuous_Subarray_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/830304546/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var mods = new HashSet<int>();
        var lastMod = 0;

        foreach (var num in nums)
        {
            lastMod = (lastMod + num) % k;

            if (!mods.Add(lastMod))
            {
                return true;
            }
        }

        return false;
    }
}
