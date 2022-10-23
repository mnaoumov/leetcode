using JetBrains.Annotations;

namespace LeetCode._0146_LRU_Cache;

[PublicAPI]
// ReSharper disable once InconsistentNaming
public interface ILRUCache
{
    public int Get(int key);
    public void Put(int key, int value);
}