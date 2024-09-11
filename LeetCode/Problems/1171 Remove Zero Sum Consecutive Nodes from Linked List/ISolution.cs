using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1171_Remove_Zero_Sum_Consecutive_Nodes_from_Linked_List;

[PublicAPI]
public interface ISolution
{
    public ListNode? RemoveZeroSumSublists(ListNode head);
}
