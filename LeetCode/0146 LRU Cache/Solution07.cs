using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200571563/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution07 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache07(capacity);
    }
}