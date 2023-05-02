using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/problems/lru-cache/submissions/845449466/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution13 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache13(capacity);
    }
}
