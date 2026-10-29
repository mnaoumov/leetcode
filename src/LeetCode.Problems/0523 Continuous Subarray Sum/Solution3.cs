namespace LeetCode.Problems._0523_Continuous_Subarray_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/830360545/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution3 : ISolution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var mods = new HashSet<int>(new[] { 0 });
        var lastMod = 0;
        var isFirstZero = true;

        foreach (var num in nums)
        {
            mods.Add(lastMod);

            if (num % k == 0)
            {
                if (isFirstZero)
                {
                    isFirstZero = false;
                    continue;
                }
            }

            lastMod = (lastMod + num) % k;

            if (mods.Contains(lastMod))
            {
                return true;
            }
        }

        return false;
    }
}
