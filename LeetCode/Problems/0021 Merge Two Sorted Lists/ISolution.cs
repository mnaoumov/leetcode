using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._0021_Merge_Two_Sorted_Lists;

[PublicAPI]
public interface ISolution
{
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2);
}
