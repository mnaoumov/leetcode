using JetBrains.Annotations;

namespace LeetCode._0460_LFU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/887130111/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public ILFUCache Create(int capacity)
    {
        return new LFUCache2(capacity);
    }
}
