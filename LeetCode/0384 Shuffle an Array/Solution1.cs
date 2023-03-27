using JetBrains.Annotations;

namespace LeetCode._0384_Shuffle_an_Array;

/// <summary>
/// https://leetcode.com/submissions/detail/923229091/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ISolutionImpl Create(int[] nums)
    {
        return new SolutionImpl1(nums);
    }
}
