namespace LeetCode.Problems._0523_Continuous_Subarray_Sum;

/// <summary>
/// https://leetcode.com/submissions/detail/830362871/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool CheckSubarraySum(int[] nums, int k)
    {
        var mods = new HashSet<int>(new[] { 0 });
        var lastMod = 0;
        var isInSequenceOfZeros = false;

        foreach (var num in nums)
        {
            if (num % k == 0)
            {
                if (!isInSequenceOfZeros)
                {
                    isInSequenceOfZeros = true;
                    continue;
                }
            }
            else
            {
                isInSequenceOfZeros = false;
            }

            lastMod = (lastMod + num) % k;

            if (!mods.Add(lastMod))
            {
                return true;
            }
        }

        return false;
    }
}
