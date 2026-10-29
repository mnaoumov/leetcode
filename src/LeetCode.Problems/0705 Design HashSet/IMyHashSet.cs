namespace LeetCode.Problems._0705_Design_HashSet;

[PublicAPI]
public interface IMyHashSet
{
    void Add(int key);
    void Remove(int key);
    bool Contains(int key);
}
