namespace LeetCode.Problems._0622_Design_Circular_Queue;

public interface IMyCircularQueue
{

    [UsedImplicitly]
    bool EnQueue(int value);

    [UsedImplicitly]
    bool DeQueue();

    [UsedImplicitly]
    int Front();

    [UsedImplicitly]
    int Rear();

    [UsedImplicitly]
    bool IsEmpty();

    [UsedImplicitly]
    bool IsFull();
}
