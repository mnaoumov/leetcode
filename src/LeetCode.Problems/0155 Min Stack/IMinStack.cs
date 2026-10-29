namespace LeetCode.Problems._0155_Min_Stack;

[PublicAPI]
public interface IMinStack
{
    void Push(int val);
    void Pop();
    int Top();
    int GetMin();
}
