using JetBrains.Annotations;

namespace LeetCode.Problems._0706_Design_HashMap;

[PublicAPI]
public interface IMyHashMap
{
    public void Put(int key, int value);
    public int Get(int key);
    public void Remove(int key);
}
