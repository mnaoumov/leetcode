namespace LeetCode.Problems._0155_Min_Stack;

/// <summary>
/// https://leetcode.com/problems/min-stack/submissions/848293212/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public IMinStack Create() => new MinStack();

    private class MinStack : IMinStack
    {
        private readonly Stack<int> _stack = new();
        private readonly Stack<int> _stackOfMins = new();

        public void Push(int val)
        {
            _stack.Push(val);
            var lastMin = _stackOfMins.TryPeek(out var lastMin2) ? lastMin2 : int.MaxValue;
            _stackOfMins.Push(Math.Min(lastMin, val));
        }

        public void Pop()
        {
            _stack.Pop();
            _stackOfMins.Pop();
        }

        public int Top() => _stack.Peek();

        public int GetMin() => _stackOfMins.Peek();
    }
}
