namespace LeetCode.Problems._0707_Design_Linked_List;

[PublicAPI]
public interface IMyLinkedList
{
    int Get(int index);
    void AddAtHead(int val);
    void AddAtTail(int val);
    void AddAtIndex(int index, int val);
    void DeleteAtIndex(int index);
}
