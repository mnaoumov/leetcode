using JetBrains.Annotations;

namespace LeetCode._0380_Insert_Delete_GetRandom_O_1_;

/// <summary>
/// https://leetcode.com/submissions/detail/851805806/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution3 : ISolution
{
    public IRandomizedSet Create()
    {
        return new RandomizedSet3();
    }
}
