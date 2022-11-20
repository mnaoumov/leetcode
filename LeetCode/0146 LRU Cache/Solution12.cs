using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/problems/lru-cache/submissions/845396253/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution12 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache12(capacity);
    }
}