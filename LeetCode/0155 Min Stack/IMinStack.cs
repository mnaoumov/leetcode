using JetBrains.Annotations;

namespace LeetCode._0155_Min_Stack;

[PublicAPI]
public interface IMinStack
{
    public void Push(int val);
    public void Pop();
    public int Top();
    public int GetMin();
}
