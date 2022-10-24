using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200573215/
/// </summary>
[UsedImplicitly]
public class Solution08 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache08(capacity);
    }
}