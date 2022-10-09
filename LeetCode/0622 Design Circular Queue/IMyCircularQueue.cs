namespace LeetCode._0622_Design_Circular_Queue;

public interface IMyCircularQueue
{
    bool EnQueue(int value);
    bool DeQueue();
    int Front();
    int Rear();
    bool IsEmpty();
    bool IsFull();
}