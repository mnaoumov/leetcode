using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200426630/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution05 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache05(capacity);
    }
}
