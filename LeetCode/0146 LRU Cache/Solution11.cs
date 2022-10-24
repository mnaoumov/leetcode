using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202712344/
/// </summary>
[UsedImplicitly]
public class Solution11 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache11(capacity);
    }
}