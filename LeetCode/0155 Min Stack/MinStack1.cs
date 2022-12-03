namespace LeetCode._0155_Min_Stack;

/// <summary>
/// https://leetcode.com/problems/min-stack/submissions/848293212/
/// </summary>
public class MinStack1 : IMinStack
{
    private readonly Stack<int> _stack;
    private readonly Stack<int> _stackOfMins;

    public MinStack1()
    {
        _stack = new Stack<int>();
        _stackOfMins = new Stack<int>();
    }

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
