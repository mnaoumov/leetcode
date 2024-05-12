using JetBrains.Annotations;

namespace LeetCode.Problems._0725_Split_Linked_List_in_Parts;

[PublicAPI]
public interface ISolution
{
    public ListNode?[] SplitListToParts(ListNode? head, int k);
}
