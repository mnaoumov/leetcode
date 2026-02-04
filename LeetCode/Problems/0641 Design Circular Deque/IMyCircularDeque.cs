namespace LeetCode.Problems._0641_Design_Circular_Deque;

[PublicAPI]
public interface IMyCircularDeque
{
    bool InsertFront(int value);
    bool InsertLast(int value);
    bool DeleteFront();
    bool DeleteLast();
    int GetFront();
    int GetRear();
    bool IsEmpty();
    bool IsFull();
}
