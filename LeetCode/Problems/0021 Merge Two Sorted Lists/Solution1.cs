

// ReSharper disable All
#pragma warning disable

namespace LeetCode.Problems._0021_Merge_Two_Sorted_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/810706460/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode? MergeTwoLists(ListNode? list1, ListNode? list2)
    {
        ListNode? node1 = list1;
        ListNode? node2 = list2;

        var fakeResultParentNode = new ListNode();
        var resultNode = fakeResultParentNode;

        while (node1 != null || node2 != null)
        {
            ref var minNode = ref node1;

            if (node1 != null)
            {
                if (node2 != null)
                {
                    if (node1.val <= node2.val)
                    {
                        minNode = ref node1;
                    }
                    else
                    {
                        minNode = ref node2;
                    }
                }
                else
                {
                    minNode = ref node1;
                }
            }
            else
            {
                minNode = ref node2;
            }

            resultNode.next = new ListNode(minNode!.val);
            resultNode = resultNode.next;
            minNode = minNode.next;
        }

        return fakeResultParentNode.next!;
    }
}
