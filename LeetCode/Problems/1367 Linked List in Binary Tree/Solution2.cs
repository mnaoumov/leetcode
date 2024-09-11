namespace LeetCode.Problems._1367_Linked_List_in_Binary_Tree;

/// <summary>
/// https://leetcode.com/submissions/detail/930970815/
/// </summary>
[UsedImplicitly]
[SkipSolution(SkipSolutionReason.WrongAnswer)]
public class Solution2 : ISolution
{
    public bool IsSubPath(ListNode head, TreeNode root) => IsSubPath2(head, root);

    private static bool IsSubPath2(ListNode? listNode, TreeNode? treeNode) =>
        listNode == null
        || treeNode != null
        && (listNode.val == treeNode.val
            && (IsSubPath2(listNode.next, treeNode.left)
                || IsSubPath2(listNode.next, treeNode.right))
            || IsSubPath2(listNode, treeNode.left)
            || IsSubPath2(listNode, treeNode.right));
}
