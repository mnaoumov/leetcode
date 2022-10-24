using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202709702/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution09 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache09(capacity);
    }
}