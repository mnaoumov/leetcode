using JetBrains.Annotations;

namespace LeetCode.Problems._0705_Design_HashSet;

/// <summary>
/// TODO url
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyHashSet Create() => new MyHashSet();

    private class MyHashSet : IMyHashSet
    {
        private const int MaxKey = 1_000_000;
        private readonly bool[] _arr = new bool[MaxKey + 1];
        public void Add(int key) => _arr[key] = true;
        public void Remove(int key) => _arr[key] = false;
        public bool Contains(int key) => _arr[key];
    }
}
