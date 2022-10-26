using JetBrains.Annotations;

namespace LeetCode._0109_Convert_Sorted_List_to_Binary_Search_Tree;

[PublicAPI]
public interface ISolution
{
    public TreeNode? SortedListToBST(ListNode? head);
}