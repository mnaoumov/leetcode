namespace LeetCode.Problems._0146_LRU_Cache;

[PublicAPI]
public interface ILRUCache
{
    int Get(int key);
    void Put(int key, int value);
}
