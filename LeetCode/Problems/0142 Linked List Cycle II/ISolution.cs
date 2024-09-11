using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0142_Linked_List_Cycle_II;

[PublicAPI]
public interface ISolution
{
    public ListNode? DetectCycle(ListNode? head);
}
