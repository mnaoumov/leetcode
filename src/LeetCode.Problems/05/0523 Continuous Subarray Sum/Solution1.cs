namespace LeetCode.Problems._0523_Continuous_Subarray_Sum;

/// <seealso href="https://leetcode.com/submissions/detail/830304546/">Submission</seealso>
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
