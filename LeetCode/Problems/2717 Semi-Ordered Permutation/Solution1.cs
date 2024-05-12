using JetBrains.Annotations;

namespace LeetCode._2717_Semi_Ordered_Permutation;

/// <summary>
/// https://leetcode.com/contest/weekly-contest-348/submissions/detail/963328531/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public int SemiOrderedPermutation(int[] nums)
    {
        var n = nums.Length;
        var index1 = Array.IndexOf(nums, 1);
        var indexN = Array.IndexOf(nums, n);
        return index1 + (n - 1 - indexN) - (index1 > indexN ? 1 : 0);
    }
}
