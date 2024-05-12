using JetBrains.Annotations;

namespace LeetCode.Problems._0109_Convert_Sorted_List_to_Binary_Search_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/830200789/
/// </summary>
[UsedImplicitly]
public class Solution1 : ISolution
{
    public TreeNode SortedListToBST(ListNode? head)
    {
        var list = new List<int>();

        var node = head;

        while (node != null)
        {
            list.Add(node.val);
            node = node.next;
        }

        return Build(0, list.Count - 1)!;

        TreeNode? Build(int left, int right)
        {
            if (left > right)
            {
                return null;
            }

            var mid = (left + right) / 2;

            return new TreeNode
            {
                val = list[mid],
                left = Build(left, mid - 1),
                right = Build(mid + 1, right)
            };
        }
    }
}
