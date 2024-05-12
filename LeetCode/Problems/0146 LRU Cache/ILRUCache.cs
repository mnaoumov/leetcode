using JetBrains.Annotations;

namespace LeetCode.Problems._0146_LRU_Cache;

[PublicAPI]
public interface ILRUCache
{
    public int Get(int key);
    public void Put(int key, int value);
}
