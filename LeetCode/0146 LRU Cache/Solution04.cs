using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200417348/
/// </summary>
[SkipSolution(SkipSolutionReason.WrongAnswer)]
[UsedImplicitly]
public class Solution04 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache04(capacity);
    }
}
