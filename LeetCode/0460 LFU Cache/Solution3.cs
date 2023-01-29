using JetBrains.Annotations;

namespace LeetCode._0460_LFU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/887131211/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ILFUCache Create(int capacity)
    {
        return new LFUCache3(capacity);
    }
}