using JetBrains.Annotations;

namespace LeetCode.Problems._1756_Design_Most_Recently_Used_Queue;

/// <summary>
/// https://leetcode.com/submissions/detail/957982869/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMRUQueue Create(int n) => new MRUQueue(n);

    private class MRUQueue : IMRUQueue
    {
        private readonly List<int> _list;

        public MRUQueue(int n) => _list = Enumerable.Range(1, n).ToList();

        public int Fetch(int k)
        {
            var value = _list[k - 1];
            _list.RemoveAt(k - 1);
            _list.Add(value);
            return value;
        }
    }
}
