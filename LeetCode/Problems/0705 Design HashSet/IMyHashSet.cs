using JetBrains.Annotations;

namespace LeetCode._0705_Design_HashSet;

[PublicAPI]
public interface IMyHashSet
{
    public void Add(int key);
    public void Remove(int key);
    public bool Contains(int key);
}
