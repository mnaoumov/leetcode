using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0092_Reverse_Linked_List_II;

[PublicAPI]
public interface ISolution
{
    public ListNode ReverseBetween(ListNode head, int left, int right);
}
