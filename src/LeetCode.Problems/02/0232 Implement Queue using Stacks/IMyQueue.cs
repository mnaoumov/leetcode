namespace LeetCode.Problems._0232_Implement_Queue_using_Stacks;

[PublicAPI]
public interface IMyQueue
{
    void Push(int x);
    int Pop();
    int Peek();
    bool Empty();
}
