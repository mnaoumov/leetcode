namespace LeetCode.Problems._0225_Implement_Stack_using_Queues;

[PublicAPI]
public interface IMyStack
{
    void Push(int x);
    int Pop();
    int Top();
    bool Empty();
}
