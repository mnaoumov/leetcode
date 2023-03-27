using JetBrains.Annotations;

namespace LeetCode._0384_Shuffle_an_Array;

/// <summary>
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public ISolutionImpl Create(int[] nums)
    {
        return new SolutionImpl2(nums);
    }
}
