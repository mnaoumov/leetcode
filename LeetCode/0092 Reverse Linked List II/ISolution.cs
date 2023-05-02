using JetBrains.Annotations;

namespace LeetCode._0092_Reverse_Linked_List_II;

[PublicAPI]
public interface ISolution
{
    public ListNode ReverseBetween(ListNode head, int left, int right);
}
