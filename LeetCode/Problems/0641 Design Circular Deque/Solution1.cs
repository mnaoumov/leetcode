namespace LeetCode.Problems._0641_Design_Circular_Deque;

/// <summary>
/// https://leetcode.com/submissions/detail/1404424595/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMyCircularDeque Create(int k) => new MyCircularDeque(k);

    private class MyCircularDeque : IMyCircularDeque
    {
        private readonly int _maxSize;
        private readonly List<int> _list;

        public MyCircularDeque(int k)
        {
            _maxSize = k;
            _list = new List<int>();
        }
    
        public bool InsertFront(int value)
        {
            if (IsFull())
            {
                return false;
            }

            _list.Insert(0, value);
            return true;
        }
    
        public bool InsertLast(int value)
        {
            if (IsFull())
            {
                return false;
            }

            _list.Add(value);
            return true;
        }
    
        public bool DeleteFront()
        {
            if (IsEmpty())
            {
                return false;
            }

            _list.RemoveAt(0);
            return true;
        }
    
        public bool DeleteLast()
        {
            if (IsEmpty())
            {
                return false;
            }

            _list.RemoveAt(_list.Count - 1);
            return true;
        }
    
        public int GetFront() => IsEmpty() ? -1 : _list[0];
        public int GetRear() => IsEmpty() ? -1 : _list[^1];
        public bool IsEmpty() => _list.Count == 0;
        public bool IsFull() => _list.Count == _maxSize;
    }
}
