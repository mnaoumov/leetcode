using JetBrains.Annotations;

namespace LeetCode.Problems._1367_Linked_List_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/930978194/
/// </summary>
[UsedImplicitly]
public class Solution4 : ISolution
{
    public bool IsSubPath(ListNode head, TreeNode root)
    {
        return IsSubPath2(head, root);

        bool IsSubPath2(ListNode? listNode, TreeNode? treeNode) =>
            listNode == null
            || treeNode != null
            && (listNode.val == treeNode.val
                && (IsSubPath2(listNode.next, treeNode.left)
                    || IsSubPath2(listNode.next, treeNode.right))
                || ReferenceEquals(listNode, head)
                && (IsSubPath2(head, treeNode.left)
                    || IsSubPath2(head, treeNode.right)));
    }
}
