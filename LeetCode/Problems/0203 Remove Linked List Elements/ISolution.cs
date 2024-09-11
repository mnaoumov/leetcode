using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0203_Remove_Linked_List_Elements;

[PublicAPI]
public interface ISolution
{
    public ListNode? RemoveElements(ListNode? head, int val);
}
