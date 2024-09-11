namespace LeetCode.Problems._0460_LFU_Cache;

[PublicAPI]
public interface ILFUCache
{
    public int Get(int key);
    public void Put(int key, int value);
}
