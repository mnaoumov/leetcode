using JetBrains.Annotations;

namespace LeetCode._0023_Merge_k_Sorted_Lists;

[PublicAPI]
public interface ISolution
{
    public ListNode? MergeKLists(ListNode?[] lists);
}