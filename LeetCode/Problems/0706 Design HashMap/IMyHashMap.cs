namespace LeetCode.Problems._0706_Design_HashMap;

[PublicAPI]
public interface IMyHashMap
{
    void Put(int key, int value);
    int Get(int key);
    void Remove(int key);
}
