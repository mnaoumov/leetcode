using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/200416329/
/// </summary>
[UsedImplicitly]
public class Solution03 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache03(capacity);
    }
}
