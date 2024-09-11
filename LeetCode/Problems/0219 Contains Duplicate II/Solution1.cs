using JetBrains.Annotations;
using LeetCode.Base;

namespace LeetCode.Problems._0219_Contains_Duplicate_II;

/// <summary>
/// https://leetcode.com/submissions/detail/826953518/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution1 : ISolution
{
    public bool ContainsNearbyDuplicate(int[] nums, int k)
    {
        if (k == 0)
        {
            return false;
        }

        if (nums.Length <= k)
        {
            return false;
        }

        var set = new HashSet<int>(capacity: k + 1);

        for (var i = 0; i < nums.Length; i++)
        {
            if (i >= k + 1)
            {
                set.Remove(nums[i - k - 1]);
            }

            if (!set.Add(nums[i]))
            {
                return true;
            }
        }

        return false;
    }
}
