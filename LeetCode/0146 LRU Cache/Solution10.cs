using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202711086/
/// </summary>
[UsedImplicitly]
public class Solution10 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache10(capacity);
    }
}