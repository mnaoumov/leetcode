namespace LeetCode._0146_LRU_Cache;

/// <summary>
/// https://leetcode.com/submissions/detail/202712344/
/// </summary>
public class Solution11 : ISolution
{
    public ILRUCache Create(int capacity)
    {
        return new LRUCache11(capacity);
    }
}