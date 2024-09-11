using JetBrains.Annotations;
using LeetCode.DataStructure;

namespace LeetCode.Problems._1669_Merge_In_Between_Linked_Lists;

[PublicAPI]
public interface ISolution
{
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2);
}
