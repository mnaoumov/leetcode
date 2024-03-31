using JetBrains.Annotations;

namespace LeetCode._1669_Merge_In_Between_Linked_Lists;

/// <summary>
/// https://leetcode.com/submissions/detail/1209517231/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public ListNode MergeInBetween(ListNode list1, int a, int b, ListNode list2)
    {
        var ansParent = new ListNode();
        var node = ansParent;

        var index1 = 0;
        for (var node1 = list1; node1 != null; node1 = node1.next)
        {
            if (index1 == a)
            {
                for (var node2 = list2; node2 != null; node2 = node2.next)
                {
                    node.next = new ListNode(node2.val);
                    node = node.next;
                }
            }
            else if (index1 < a || b < index1)
            {
                node.next = new ListNode(node1.val);
                node = node.next;
            }

            index1++;
        }

        return ansParent.next!;
    }
}
