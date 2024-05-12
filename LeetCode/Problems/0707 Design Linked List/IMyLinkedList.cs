using JetBrains.Annotations;

namespace LeetCode._0707_Design_Linked_List;

[PublicAPI]
public interface IMyLinkedList
{
    public int Get(int index);
    public void AddAtHead(int val);
    public void AddAtTail(int val);
    public void AddAtIndex(int index, int val);
    public void DeleteAtIndex(int index);
}
