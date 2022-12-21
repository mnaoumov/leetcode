namespace LeetCode._0232_Implement_Queue_using_Stacks;

/// <summary>
/// https://leetcode.com/submissions/detail/860437570/
/// </summary>
public class MyQueue1 : IMyQueue
{
    private readonly Stack<int> _reversedStack = new();
    private readonly Stack<int> _directStack = new();

    public void Push(int x) => _reversedStack.Push(x);

    public int Pop()
    {
        MoveToDirectStackIfNeeded();
        return _directStack.Pop();
    }

    private void MoveToDirectStackIfNeeded()
    {
        if (_directStack.Count > 0)
        {
            return;
        }

        while (_reversedStack.Count > 0)
        {
            _directStack.Push(_reversedStack.Pop());
        }
    }

    public int Peek()
    {
        MoveToDirectStackIfNeeded();
        return _directStack.Peek();
    }

    public bool Empty() => _reversedStack.Count == 0 && _directStack.Count == 0;
}
