using JetBrains.Annotations;

namespace LeetCode._0019_Remove_Nth_Node_From_End_of_List;

[PublicAPI]
public interface ISolution
{
    ListNode RemoveNthFromEnd(ListNode head, int n);
}