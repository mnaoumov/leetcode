using JetBrains.Annotations;

namespace LeetCode._0460_LFU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/887127869/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.RuntimeError)]
public class Solution1 : ISolution
{
    public ILFUCache Create(int capacity)
    {
        return new LFUCache1(capacity);
    }
}
