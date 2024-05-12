using JetBrains.Annotations;

namespace LeetCode.Problems._0225_Implement_Stack_using_Queues;

/// <summary>
/// https://leetcode.com/submissions/detail/903005475/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyStack Create() => new MyStack();

    private class MyStack : IMyStack
    {
        private readonly Queue<int> _queue = new();
        private int _top;

        public void Push(int x)
        {
            _queue.Enqueue(x);
            _top = x;
        }

        public int Pop()
        {
            var count = _queue.Count;

            for (var i = 0; i < count - 1; i++)
            {
                Push(_queue.Dequeue());
            }

            return _queue.Dequeue();
        }

        public int Top() => _top;

        public bool Empty() => _queue.Count == 0;
    }
}
