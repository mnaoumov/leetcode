namespace LeetCode.Problems._0460_LFU_Cache;

[PublicAPI]
public interface ILFUCache
{
    int Get(int key);
    void Put(int key, int value);
}
