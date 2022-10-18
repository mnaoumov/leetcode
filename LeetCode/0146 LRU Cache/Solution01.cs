using JetBrains.Annotations;
// ReSharper disable All

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200414387/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution01 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache01(capacity);
    }
}