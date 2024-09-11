namespace LeetCode.Problems._0232_Implement_Queue_using_Stacks;

[PublicAPI]
public interface IMyQueue
{
    public void Push(int x);
    public int Pop();
    public int Peek();
    public bool Empty();
}
