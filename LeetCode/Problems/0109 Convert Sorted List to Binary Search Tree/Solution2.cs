using JetBrains.Annotations;

namespace LeetCode._0109_Convert_Sorted_List_to_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/830208845/
/// </summary>
[UsedImplicitly]
public class Solution2 : ISolution
{
    public TreeNode? SortedListToBST(ListNode? head)
    {
        return Build(head, null);
    }

    private static TreeNode? Build(ListNode? head, ListNode? tail)
    {
        if (ReferenceEquals(head, tail))
        {
            return null;
        }

        var node = head;
        var doubleSpeedNode = head!.next;

        while (!ReferenceEquals(doubleSpeedNode, tail))
        {
            node = node!.next;

            doubleSpeedNode = doubleSpeedNode!.next;

            if (ReferenceEquals(doubleSpeedNode, tail))
            {
                break;
            }

            doubleSpeedNode = doubleSpeedNode!.next;
        }

        return new TreeNode
        {
            val = node!.val,
            left = Build(head, node),
            right = Build(node.next, tail)
        };
    }
}
