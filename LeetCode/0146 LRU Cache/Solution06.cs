using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200571222/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution06 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache06(capacity);
    }
}