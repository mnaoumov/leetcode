using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/problems/lru-cache/submissions/845501362/
/// </summary>
[UsedImplicitly]
public class Solution15 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache15(capacity);
    }
}
