namespace LeetCode.Problems._0021_Merge_Two_Sorted_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/923208181/
/// </summary>
[UsedImplicitly]
public class Solution3 : ISolution
{
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        if (list1 == null)
        {
            return list2;
        }

        if (list2 == null)
        {
            return list1;
        }

        return list1.val <= list2.val
            ? new ListNode(list1.val, MergeTwoLists(list1.next, list2))
            : new ListNode(list2.val, MergeTwoLists(list1, list2.next));
    }
}
