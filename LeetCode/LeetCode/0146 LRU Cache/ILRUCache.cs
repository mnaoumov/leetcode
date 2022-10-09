namespace LeetCode._0146_LRU_Cache;

public interface ILRUCache
{
    public int Get(int key);
    public void Put(int key, int value);
}