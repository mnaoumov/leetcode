namespace LeetCode.Problems._0641_Design_Circular_Deque;

[PublicAPI]
public interface IMyCircularDeque
{
    public bool InsertFront(int value);
    public bool InsertLast(int value);
    public bool DeleteFront();
    public bool DeleteLast();
    public int GetFront();
    public int GetRear();
    public bool IsEmpty();
    public bool IsFull();
}
