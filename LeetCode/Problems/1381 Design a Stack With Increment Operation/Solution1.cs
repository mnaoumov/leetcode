namespace LeetCode.Problems._1381_Design_a_Stack_With_Increment_Operation;

/// <summary>
/// https://leetcode.com/submissions/detail/1406653352/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ICustomStack Create(int maxSize) => new CustomStack(maxSize);

    private class CustomStack : ICustomStack
    {
        private readonly int[] _arr;
        private int _size;

        public CustomStack(int maxSize) => _arr = new int[maxSize];

        public void Push(int x)
        {
            if (_size == _arr.Length)
            {
                return;
            }

            _arr[_size] = x;
            _size++;
        }
    
        public int Pop()
        {
            if (_size == 0)
            {
                return -1;
            }

            var last = _arr[_size - 1];
            _size--;
            return last;
        }
    
        public void Increment(int k, int val)
        {
            for (var i = 0; i < Math.Min(k, _size); i++)
            {
                _arr[i] += val;
            }
        }
    }
}
