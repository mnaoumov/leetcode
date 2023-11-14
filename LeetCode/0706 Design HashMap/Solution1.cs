using JetBrains.Annotations;

namespace LeetCode._0706_Design_HashMap;

/// <summary>
/// https://leetcode.com/submissions/detail/931645022/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyHashMap Create() => new MyHashMap();

    private class MyHashMap : IMyHashMap
    {
        private const int MaxValue = 1_000_000;
        private const int NoValue = -1;
        private readonly int[] _arr = Enumerable.Repeat(NoValue, MaxValue + 1).ToArray();

        public void Put(int key, int value) => _arr[key] = value;
        public int Get(int key) => _arr[key];
        public void Remove(int key) => _arr[key] = NoValue;
    }
}
