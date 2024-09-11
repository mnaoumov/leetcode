namespace LeetCode.Problems._0225_Implement_Stack_using_Queues;

[PublicAPI]
public interface IMyStack
{
    public void Push(int x);
    public int Pop();
    public int Top();
    public bool Empty();
}
